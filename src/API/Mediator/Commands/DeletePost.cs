using MediatR;

namespace API.Mediator.Commands;
public record DeletePost : IRequest
{
    public int Id { get; set; }
}