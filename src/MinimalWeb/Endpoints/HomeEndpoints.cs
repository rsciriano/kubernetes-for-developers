namespace MinimalWeb.Endpoints;

public static class HomeEndpoints
{
    public static RouteGroupBuilder MapHomeEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("", GetHomePage);

        return group;
    }

    private static async Task<IResult> GetHomePage(Services.ProcessEmulator processEmulator)
    {
        var result = await processEmulator.RunProcess();

        return Results.Extensions.Html($"""
        <!doctype html>
        <html>
            <head><title>Kubernetes demo</title></head>
            <body>
                <h1>Welcome to the Kubernetes demo!!!</h1>
                <table style="font-size:x-large;border: dotted;">
                    <tr>
                        <td>Machine name:</td><td>{Environment.MachineName}</td>
                    </tr>
                    <tr>
                        <td>Proccess duration:</td><td>{result.Duration}</td>
                    </tr>
                </table>
            </body>
        </html>
        """);
    }
}
