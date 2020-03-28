using Core.Interfaces.Data;
using Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Msi.Extensions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void Seeds<TEntity, TSeed>(this ModelBuilder modelBuilder) where TEntity : class, IEntity
          where TSeed : ISeed<TEntity>, new()
        {
            modelBuilder.Entity<TEntity>().HasData(new TSeed().GetSeeds());
        }

        public static void Seeds(this ModelBuilder modelBuilder)
        {
            var assemblies = ExtensionManager.Assemblies;
            var seedType = typeof(ISeed<>);

            List<ISeed<IEntity>> permissionSeeds = new List<ISeed<IEntity>>();
            List<ISeed<IEntity>> rolePermissionSeeds = new List<ISeed<IEntity>>();
            List<ISeed<IEntity>> seeds = new List<ISeed<IEntity>>();

            foreach (Assembly assembly in assemblies)
            {
                var exportedTypes = assembly.GetExportedTypes();
                foreach (Type exportedType in exportedTypes)
                {
                    var interfaces = exportedType.GetInterfaces().Where(x => x.IsGenericType);
                    foreach (var @interface in interfaces)
                    {
                        if (@interface.GetGenericTypeDefinition() == seedType)
                        {
                            var args = @interface.GetGenericArguments();
                            foreach (var arg in args)
                            {
                                ISeed<IEntity> instance = (ISeed<IEntity>)Activator.CreateInstance(exportedType);
                                if (arg.Name == "RolePermission")
                                {
                                    rolePermissionSeeds.Add(instance);
                                }
                                else if (arg.Name == "Permission")
                                {
                                    permissionSeeds.Add(instance);
                                }
                                else
                                {
                                    seeds.Add(instance);
                                }
                            }
                        }
                    }
                }
            }

            if(seeds.Count > 0)
            {
                seeds = seeds.OrderBy(x => x.Order).ToList();
                foreach (var seed in seeds)
                {
                    modelBuilder.Seeds(seed);
                }
            }

            if(permissionSeeds.Count > 0)
            {
                var _permissionSeeds = permissionSeeds.SelectMany(x => x.GetSeeds());
                modelBuilder.PermissionSeeds(permissionSeeds[0], _permissionSeeds);
            }

            if(rolePermissionSeeds.Count > 0)
            {
                var _rolePermissionSeeds = rolePermissionSeeds.SelectMany(x => x.GetSeeds());
                modelBuilder.PermissionSeeds(rolePermissionSeeds[0], _rolePermissionSeeds);
            }


        }

        public static void Seeds(this ModelBuilder modelBuilder, ISeed<IEntity> seed)
        {
            var interfaces = seed.GetType().GetInterfaces();
            if(interfaces.Count() > 0)
            {
                var args = interfaces[0].GetGenericArguments();
                if(args.Count() > 0)
                {
                    var type = args[0];
                    modelBuilder.Entity(type).HasData(seed.GetSeeds());
                }
            }
        }

        private static void PermissionSeeds(this ModelBuilder modelBuilder, ISeed<IEntity> seed, IEnumerable<IEntity> seeds)
        {
            var interfaces = seed.GetType().GetInterfaces();
            if (interfaces.Count() > 0)
            {
                var args = interfaces[0].GetGenericArguments();
                if (args.Count() > 0)
                {
                    var type = args[0];
                    modelBuilder.Entity(type).HasData(seeds);
                }
            }
        }
    }
}
