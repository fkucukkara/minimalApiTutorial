using Domain.Models;
using MediatR;

namespace API.Mediator.Queries;
public class GetPosts : IRequest<IEnumerable<Post>>
{
}