using MediatR;

namespace Msi.Mediator.Abstractions
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
