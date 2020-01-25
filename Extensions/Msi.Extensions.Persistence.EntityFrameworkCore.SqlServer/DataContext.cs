using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Msi.Extensions.Persistence.Abstractions;

namespace Msi.Extensions.Persistence.EntityFrameworkCore.SqlServer
{
    public class DataContext : DataContextBase
    {
        public DataContext(IOptions<DataContextOptions> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (string.IsNullOrEmpty(MigrationsAssembly))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(ConnectionString, options =>
                {
                    options.MigrationsAssembly(MigrationsAssembly);
                });
            }
        }
    }
}
