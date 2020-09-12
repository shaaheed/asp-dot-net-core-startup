using MediatR;

namespace Msi.Mediator.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
