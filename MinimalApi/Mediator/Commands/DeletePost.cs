using MediatR;

namespace MinimalApi.Mediator.Commands
{
    public class DeletePost : IRequest
    {
        public int Id { get; set; }
    }
}
