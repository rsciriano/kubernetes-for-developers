using Microsoft.Extensions.Diagnostics.HealthChecks;
using MinimalWeb.Services;

namespace MinimalWeb.HealthChecks;

public class ProcessEmulatorInitializationHealthCheck: IHealthCheck
{
    private readonly ProcessEmulator _processEmulator;

    public ProcessEmulatorInitializationHealthCheck(ProcessEmulator processEmulator)
    {
        this._processEmulator = processEmulator;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var initializationTask = _processEmulator.Initialize();

        var res = initializationTask.WaitAsync(TimeSpan.FromMilliseconds(1000), cancellationToken);

        var isHealthy = res.IsCompletedSuccessfully;

        if (isHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Proccess emulator initialized sucessfully."));
        }

        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "The process emulator has not initialized yet."));
    }
}