using Domain.Models;
using MediatR;

namespace MinimalApi.Mediator.Queries
{
    public class GetPost : IRequest<Post>
    {
        public int Id { get; set; }
    }
}
