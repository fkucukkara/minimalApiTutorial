using MediatR;
using MinimalApi.Mediator.Queries;

namespace MinimalApi.Endpoints.V1.GetById
{
    public static class Endpoint
    {
        public static WebApplication MapGetPost(this WebApplication app)
        {
            app.MapGet("/api/v1/posts/{id}", async (IMediator mediator, int id) =>
            {
                var post = await mediator.Send(new GetPost() { Id = id });
                return Results.Ok(post);
            });
            return app;
        }
    }
}
