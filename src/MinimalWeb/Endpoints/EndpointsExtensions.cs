namespace MinimalWeb.Endpoints;

public static class EndpointsExtensions
{
    public static RouteGroupBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/");

        group.MapHomeEndpoints();

        return group;
    }
}
