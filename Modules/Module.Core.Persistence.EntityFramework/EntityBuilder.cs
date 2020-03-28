using Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Entities;
using Msi.Extensions.Infrastructure;
using Msi.Extensions.Persistence.EntityFrameworkCore;
using System.Linq;

namespace Module.Core.Persistence.EntityFramework
{
    public class EntityBuilder : IModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            var types = ExtensionManager.GetImplementations<IEntity>()
                .Where(x => x.Name != "BaseEntity" && !x.Name.Contains("BaseEntityWithTypeId"));
            foreach (var type in types)
            {
                modelBuilder.Entity(type).Ignore("PendingEvents");
            }
        }
    }
}
