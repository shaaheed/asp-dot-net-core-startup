using MediatR;

namespace Core.Infrastructure.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
