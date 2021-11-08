using System.Collections.Generic;

namespace Msi.Mediator.Abstractions
{
    public interface IListQuery<TEntity, TResponse> : IQuery<TResponse> where TResponse : IEnumerable<TResponse>
    {
    }
}
