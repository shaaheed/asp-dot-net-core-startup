using MediatR;

namespace Msi.Mediator.Abstractions
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        //
    }
}
