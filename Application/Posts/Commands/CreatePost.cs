using MediatR;

namespace Application.Posts.Commands
{
    public class CreatePost:IRequest<Post>
    {
    }
}
