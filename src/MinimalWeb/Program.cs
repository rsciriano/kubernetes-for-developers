using Microsoft.AspNetCore.Http.Timeouts;
using MinimalWeb.Endpoints;
using MinimalWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
        .AddApplicationInsightsTelemetry()
        .AddApplicationInsightsKubernetesEnricher(diagnosticLogLevel: LogLevel.Information)
        .AddSingleton<ProcessEmulator>()
        .AddRequestTimeouts(options =>
         {
             var requestTimeoutMs = builder.Configuration.GetValue<int?>("RequestTimeoutMs");
             if (requestTimeoutMs.HasValue)
             {
                 options.DefaultPolicy = new RequestTimeoutPolicy
                 { Timeout = TimeSpan.FromMilliseconds(requestTimeoutMs.Value) };
             }
         });


var app = builder.Build();
app.UseRequestTimeouts();
app.MapEndpoints();
app.Run();
