using System.Collections.Generic;

namespace Msi.Data.Entity
{
    public interface ISeed<out TEntity> where TEntity : IEntity
    {
        int Order { get; }

        IEnumerable<TEntity> GetSeeds();
    }
}
