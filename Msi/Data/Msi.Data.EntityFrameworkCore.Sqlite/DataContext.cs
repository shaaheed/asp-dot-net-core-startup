using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore.Sqlite
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
                optionsBuilder.UseSqlite(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlite(ConnectionString, options =>
                {
                    options.MigrationsAssembly(MigrationsAssembly);
                });
            }
        }
    }
}
