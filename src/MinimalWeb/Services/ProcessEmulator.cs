namespace MinimalWeb.Services;

public class ProcessEmulator
{
    private Task? initializationTask;

    public Task Initialize(CancellationToken cancellationToken = default)
    {
        return Task.Delay(Random.Shared.Next(5000, 10000), cancellationToken);
    }

    protected async Task EnsureInitialization(CancellationToken cancellationToken = default)
    {
        if (initializationTask is null)
        {
            initializationTask = Initialize();
        }

        await initializationTask.WaitAsync(TimeSpan.FromMilliseconds(1000), cancellationToken);

    }

    public async Task<ProcessResult> RunProcess(CancellationToken cancellationToken = default)
    {
        await EnsureInitialization(cancellationToken);

        var sp = System.Diagnostics.Stopwatch.StartNew();

        await Task.Delay(Random.Shared.Next(10, 2000), cancellationToken);

        return new ProcessResult {Duration = sp.Elapsed};
    }
}

public class ProcessResult
{
    public TimeSpan Duration { get; set; }
}
