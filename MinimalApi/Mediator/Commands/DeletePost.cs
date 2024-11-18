using MediatR;

namespace MinimalApi.Mediator.Commands;
public record DeletePost : IRequest
{
    public int Id { get; set; }
}