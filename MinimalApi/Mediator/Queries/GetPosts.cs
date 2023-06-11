using Domain.Models;
using MediatR;

namespace MinimalApi.Mediator.Queries
{
    public class GetPosts : IRequest<IList<Post>>
    {
    }
}
