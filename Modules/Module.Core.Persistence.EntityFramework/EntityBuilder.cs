//using Core.Infrastructure.Attributes;
//using Core.Interfaces.Entities;
//using Microsoft.EntityFrameworkCore;
//using Module.Users.Entities;
//using Msi.Extensions.Infrastructure;
//using Msi.Data.EntityFrameworkCore;
//using System.Linq;

//namespace Module.Core.Persistence.EntityFramework
//{
//    public class EntityBuilder : IModelBuilder
//    {
//        public void Build(ModelBuilder modelBuilder)
//        {
//            var types = ExtensionManager.GetImplementations<IEntity>()
//                .Where(x =>
//                {
//                    var ignoredEntity = x.CustomAttributes.Any(y => y.AttributeType == typeof(IgnoredEntityAttribute));
//                    return !ignoredEntity;
//                });
//            foreach (var type in types)
//            {
//                modelBuilder.Entity(type).Ignore("PendingEvents");
//            }
//            //modelBuilder.Entity<RolePermission>().Property(x => x.PermissionId)
//        }
//    }
//}
