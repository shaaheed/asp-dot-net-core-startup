using System;
using System.Linq.Expressions;

namespace Msi.Domain.Abstractions
{
    public interface IViewModel<TEntity, TViewModel>
    {
        Expression<Func<TEntity, TViewModel>> Selector();
    }
}
