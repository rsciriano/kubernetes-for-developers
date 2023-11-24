using Microsoft.Extensions.Diagnostics.HealthChecks;
using MinimalWeb.Services;

namespace MinimalWeb.HealthChecks;

public class ProcessEmulatorIsAliveHealthCheck: IHealthCheck
{
    private readonly ProcessEmulator _processEmulator;

    public ProcessEmulatorIsAliveHealthCheck(ProcessEmulator processEmulator)
    {
        this._processEmulator = processEmulator;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = _processEmulator.IsAlive();

        if (isHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Proccess emulator is alive."));
        }

        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "The process emulator has not alive."));
    }
}