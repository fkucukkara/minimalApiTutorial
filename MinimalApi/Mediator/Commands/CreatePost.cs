using Domain.Models;
using MediatR;

namespace MinimalApi.Mediator.Commands;
public record CreatePost : IRequest<Post>
{
    public Post? Post { get; set; }
}