using MediatR;

namespace Core.Infrastructure.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
