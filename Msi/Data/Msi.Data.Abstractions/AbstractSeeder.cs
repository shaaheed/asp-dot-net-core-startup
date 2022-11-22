using Msi.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{
    public abstract class AbstractSeeder<TEntity> : ISeeder<TEntity> where TEntity : class, IGuidEntity
    {
        public virtual int Order => 0;

        public virtual IEnumerable<TEntity> GetSeeds() => Enumerable.Empty<TEntity>();

        public async Task Seed(IUnitOfWork unitOfWork)
        {
            var repo = unitOfWork.GetRepository<TEntity>();
            var seedEntities = GetSeeds();
            foreach (var seedEntity in seedEntities)
            {
                var count = await repo.CountAsync(x => x.Id == seedEntity.Id);
                if (count <= 0)
                {
                    await repo.AddAsync(seedEntity);
                }
                else
                {
                    repo.Update(seedEntity);
                }
            }
        }
    }
}
