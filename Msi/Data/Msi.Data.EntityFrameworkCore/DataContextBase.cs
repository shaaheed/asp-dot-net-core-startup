using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Data.Entity;
using System;
using System.Linq;

namespace Msi.Data.EntityFrameworkCore
{
    public abstract class DataContextBase : DbContext, IDataContext
    {
        public string ConnectionString { get; private set; }
        public string MigrationsAssembly { get; private set; }

        public DataContextBase(IOptions<DataContextOptions> options) : this(options.Value)
        {

        }

        public DataContextBase(DataContextOptions options)
        {
            ConnectionString = options.ConnectionString;
            MigrationsAssembly = options.MigrationsAssembly;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("---- OnModelCreating ----");
            var entities = Global.GetImplementations<IEntity>();
            foreach (var item in entities)
            {
                var ignored = item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoredEntityAttribute));
                if(!ignored)
                {
                    modelBuilder.Entity(item);
                }
            }

            //var seeds = Global.GetInstances<ISeed<IEntity>>().OrderBy(x => x.Order);
            //foreach (var item in seeds)
            //{
            //    modelBuilder.AddSeeds(item);
            //}

            var modelBuilders = Global.GetInstances<IModelBuilder>();
            foreach (var item in modelBuilders)
            {
                item.Build(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
