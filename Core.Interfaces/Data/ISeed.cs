using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Core.Interfaces.Data
{
    public interface ISeed<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetSeeds();
    }
}
