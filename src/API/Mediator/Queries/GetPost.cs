using Domain.Models;
using MediatR;

namespace API.Mediator.Queries;
public class GetPost : IRequest<Post>
{
    public int Id { get; set; }
}