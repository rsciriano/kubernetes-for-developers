using MinimalWeb.Endpoints;
using MinimalWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
        .AddApplicationInsightsTelemetry()
        .AddApplicationInsightsKubernetesEnricher(diagnosticLogLevel: LogLevel.Information)
        .AddSingleton<ProcessEmulator>();


var app = builder.Build();

app.MapEndpoints();

app.Run();
