using Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Msi.Extensions.Infrastructure;
using Msi.Extensions.Persistence.EntityFrameworkCore;

namespace Module.Sales.Persistence.EntityFramework
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelBuilder)
        {
            var types = ExtensionManager.GetImplementations<IEntity>();
            foreach (var type in types)
            {
                modelBuilder.Entity(type);
            }
            modelBuilder.Entity<BaseEntity>().Ignore(x => x.PendingEvents);
        }
    }
}
