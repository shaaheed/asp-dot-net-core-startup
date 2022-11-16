//using Core.Interfaces.Data;
//using Msi.Data.Entity;
//using Microsoft.EntityFrameworkCore;
//using Msi.Extensions.Infrastructure;
//using Msi.UtilityKit;
//using System;
//using System.Linq;

//namespace Msi.Data.EntityFrameworkCore
//{
//    public static class ModelBuilderExtensions
//    {
//        public static void Seeds<TEntity, TSeed>(this ModelBuilder modelBuilder) where TEntity : class, IEntity
//          where TSeed : ISeed<TEntity>, new()
//        {
//            modelBuilder.Entity<TEntity>().HasData(new TSeed().GetSeeds());
//        }

//        public static void Seeds(this ModelBuilder modelBuilder)
//        {
//            var assemblies = ExtensionManager.Assemblies;
//            var seedType = typeof(ISeed<>);

//            List<ISeed<IEntity>> permissionSeeds = new List<ISeed<IEntity>>();
//            List<ISeed<IEntity>> rolePermissionSeeds = new List<ISeed<IEntity>>();
//            List<ISeed<IEntity>> seeds = new List<ISeed<IEntity>>();

//            foreach (Assembly assembly in assemblies)
//            {
//                var exportedTypes = assembly.GetExportedTypes();
//                foreach (Type exportedType in exportedTypes)
//                {
//                    var interfaces = exportedType.GetInterfaces().Where(x => x.IsGenericType);
//                    foreach (var @interface in interfaces)
//                    {
//                        if (@interface.GetGenericTypeDefinition() == seedType)
//                        {
//                            var args = @interface.GetGenericArguments();
//                            foreach (var arg in args)
//                            {
//                                ISeed<IEntity> instance = (ISeed<IEntity>)Activator.CreateInstance(exportedType);
//                                if (arg.Name == "RolePermission")
//                                {
//                                    rolePermissionSeeds.Add(instance);
//                                }
//                                else if (arg.Name == "Permission")
//                                {
//                                    permissionSeeds.Add(instance);
//                                }
//                                else
//                                {
//                                    seeds.Add(instance);
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            if(seeds.Count > 0)
//            {
//                seeds = seeds.OrderBy(x => x.Order).ToList();
//                foreach (var seed in seeds)
//                {
//                    modelBuilder.Seeds(seed);
//                }
//            }

//            if(permissionSeeds.Count > 0)
//            {
//                var _permissionSeeds = permissionSeeds.SelectMany(x => x.GetSeeds());
//                modelBuilder.PermissionSeeds(permissionSeeds[0], _permissionSeeds);
//            }

//            if(rolePermissionSeeds.Count > 0)
//            {
//                var _rolePermissionSeeds = rolePermissionSeeds.SelectMany(x => x.GetSeeds());
//                //modelBuilder.PermissionSeeds(rolePermissionSeeds[0], _rolePermissionSeeds);
//                string sql = "set foreign_key_checks=0;\n";
//                foreach (var s in _rolePermissionSeeds)
//                {
//                    long id = s.GetValue<long>("Id");
//                    string permissionId = s.GetValue<string>("PermissionId");
//                    long roleId = s.GetValue<long>("RoleId");
//                    string ql = $"insert into rolepermission (Id, RoleId, PermissionId) values ({id}, {roleId}, \"{permissionId}\");\n";
//                    sql += ql;
//                }
//                sql += "set foreign_key_checks=1;";
//                string path = AppContext.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp3.1\\", "") + "\\sql.txt";
//                File.WriteAllText(path, sql);
//            }



//        }

//        public static void Seeds(this ModelBuilder modelBuilder, ISeed<IEntity> seed)
//        {
//            var interfaces = seed.GetType().GetInterfaces();
//            if(interfaces.Count() > 0)
//            {
//                var args = interfaces[0].GetGenericArguments();
//                if(args.Count() > 0)
//                {
//                    var type = args[0];
//                    modelBuilder.Entity(type).HasData(seed.GetSeeds());
//                }
//            }
//        }

//        private static void PermissionSeeds(this ModelBuilder modelBuilder, ISeed<IEntity> seed, IEnumerable<IEntity> seeds)
//        {
//            var interfaces = seed.GetType().GetInterfaces();
//            if (interfaces.Count() > 0)
//            {
//                var args = interfaces[0].GetGenericArguments();
//                if (args.Count() > 0)
//                {
//                    var type = args[0];
//                    modelBuilder.Entity(type).HasData(seeds);
//                }
//            }
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using Msi.Data.Entity;

public static class ModelBuilderExtensions
{

    public static List<string> seedTracking = new List<string>();

    public static void AddSeeds(this ModelBuilder modelBuilder, ISeed<IEntity> seed)
    {
        var seedType = seed.GetType();
        var typeStr = seedType.ToString();
        if (!seedTracking.Contains(typeStr))
        {
            seedTracking.Add(typeStr);
            var interfaces = seed.GetType().GetInterfaces();
            if (interfaces.Count() > 0)
            {
                var args = interfaces[0].GetGenericArguments();
                if (args.Count() > 0)
                {
                    var type = args[0];
                    Console.Write("****** ");
                    Console.Write(type.ToString());
                    Console.Write(" ****** \n");
                    modelBuilder.Entity(type).HasData(seed.GetSeeds().ToArray());
                }
            }
        }
    }

}
