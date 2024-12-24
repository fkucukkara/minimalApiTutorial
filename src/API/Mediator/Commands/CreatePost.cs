namespace API.Mediator.Commands;
public record CreatePost : IRequest<Post>
{
    public Post? Post { get; set; }
}