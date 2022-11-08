using MediatR;

namespace Msi.Mediator.Abstractions
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
