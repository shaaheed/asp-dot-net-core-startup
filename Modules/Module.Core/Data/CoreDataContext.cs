//using Core.Interfaces.Entities;
//using Core.Web.Modules;
//using Msi.Extensions.Persistence.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace Modules.Core.Data
//{
//    public class CoreDataContext : DataContextBase
//    {

//        public CoreDataContext() : base() { }

//        public CoreDataContext(DbContextOptions<CoreDataContext> options) : base(options)
//        {

//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDataContext).Assembly);

//            List<Type> typeToRegisters = new List<Type>();
//            foreach (var module in ModuleManager.Modules)
//            {
//                typeToRegisters.AddRange(module.Assembly.DefinedTypes.Select(t => t.AsType()));
//                typeToRegisters.AddRange(module.DependentAssemblies.SelectMany(x => x.DefinedTypes).Select(x => x.AsType()));
//            }

//            RegisterEntities(modelBuilder, typeToRegisters);

//            RegisterConvention(modelBuilder);

//            base.OnModelCreating(modelBuilder);

//            //RegisterCustomMappings(modelBuilder, typeToRegisters);
//        }

//        //private void ValidateEntities()
//        //{
//        //    var modifiedEntries = ChangeTracker.Entries()
//        //            .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

//        //    foreach (var entity in modifiedEntries)
//        //    {
//        //        if (entity.Entity is ValidatableObject validatableObject)
//        //        {
//        //            var validationResults = validatableObject.Validate();
//        //            if (validationResults.Any())
//        //            {
//        //                throw new ValidationException(entity.Entity.GetType(), validationResults);
//        //            }
//        //        }
//        //    }
//        //}

//        private static void RegisterEntities(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
//        {
//            var entityTypes = typeToRegisters.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(BaseEntity)) && !x.GetTypeInfo().IsAbstract);
//            foreach (var type in entityTypes)
//            {
//                EntityTypeBuilder entityTypeBuilder = modelBuilder.Entity(type);
//                entityTypeBuilder.Ignore(nameof(BaseEntity.PendingEvents));
//            }
//        }

//        private static void RegisterCustomMappings(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
//        {
//            var customModelBuilderTypes = typeToRegisters.Where(x => typeof(IModelBuilder).IsAssignableFrom(x));
//            foreach (var builderType in customModelBuilderTypes)
//            {
//                if (builderType != null && builderType != typeof(IModelBuilder))
//                {
//                    var customModelBuilder = (IModelBuilder)Activator.CreateInstance(builderType);
//                    if (!string.IsNullOrEmpty(customModelBuilder.DefaultSchema))
//                    {
//                        modelBuilder.HasDefaultSchema(customModelBuilder.DefaultSchema);
//                    }

//                    // customModelBuilder.Build(modelBuilder);
//                }
//            }
//        }

//        private static void RegisterConvention(ModelBuilder modelBuilder)
//        {
//            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
//            //{
//            //    if (entity.ClrType.Namespace != null)
//            //    {
//            //        var nameParts = entity.ClrType.Namespace.Split('.');
//            //        var tableName = string.Concat(nameParts[2], "_", entity.ClrType.Name);
//            //        modelBuilder.Entity(entity.Name).ToTable(tableName);
//            //    }
//            //}

//            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
//            {
//                relationship.DeleteBehavior = DeleteBehavior.Restrict;
//            }
//        }

//    }
//}
