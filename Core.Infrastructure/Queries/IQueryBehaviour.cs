using MediatR;

namespace Core.Infrastructure.Queries
{
    public interface IQueryBehaviour<in TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //
    }
}
