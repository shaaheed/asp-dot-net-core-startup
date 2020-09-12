using MediatR;

namespace Msi.Mediator.Abstractions
{
    public interface IQueryBehaviour<in TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //
    }
}
