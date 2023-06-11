using MediatR;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Endpoints.V1.GetAll
{
    public static class Endpoint
    {
        public static WebApplication MapGetAllPosts(this WebApplication app)
        {
            app.MapGet("/api/v1/posts", async (IMediator mediator) =>
            {
                var posts = await mediator.Send(new GetPosts());
                return Results.Ok(posts);
            });
            return app;
        }
    }
}
