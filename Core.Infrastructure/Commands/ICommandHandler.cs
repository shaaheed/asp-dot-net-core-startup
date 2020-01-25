using MediatR;

namespace Core.Infrastructure.Commands
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        //
    }
}
