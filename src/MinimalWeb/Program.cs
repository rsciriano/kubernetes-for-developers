using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MinimalWeb.Endpoints;
using MinimalWeb.HealthChecks;
using MinimalWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
        .AddApplicationInsightsTelemetry()
        .AddApplicationInsightsKubernetesEnricher(diagnosticLogLevel: LogLevel.Information)
        .AddSingleton<ProcessEmulator>();

builder.Services.AddHealthChecks()
    .AddCheck<ProcessEmulatorInitializationHealthCheck>(
        "ProcessEmulatorInitialization",
        tags: new[] { "startup" })
    .AddCheck<ProcessEmulatorIsAliveHealthCheck>(
        "ProcessEmulatorIsAlive",
        tags: new[] { "readiness", "liveness" });

var app = builder.Build();

app.MapHealthChecks("/probes/startup", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("startup")
});

app.MapHealthChecks("/probes/readiness", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("readiness")
});
    
app.MapHealthChecks("/probes/liveness", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("liveness")
});



app.MapEndpoints();


app.Run();
