using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Msi.Extensions.Persistence.Abstractions;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public abstract class DataContextBase : DbContext, IDataContext
    {

        public string ConnectionString { get; private set; }
        public string MigrationsAssembly { get; private set; }

        public DataContextBase(IOptions<DataContextOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
            MigrationsAssembly = options.Value.MigrationsAssembly;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.BuildModels(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

    }
}
