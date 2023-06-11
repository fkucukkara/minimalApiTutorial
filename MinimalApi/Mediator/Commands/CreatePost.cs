using Domain.Models;
using MediatR;

namespace MinimalApi.Mediator.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public Post? Post { get; set; }
    }
}
