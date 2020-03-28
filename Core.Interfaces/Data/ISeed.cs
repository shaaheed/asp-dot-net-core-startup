using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Core.Interfaces.Data
{
    public interface ISeed<out TEntity> where TEntity : IEntity
    {
        int Order { get; }

        IEnumerable<TEntity> GetSeeds();
    }
}
