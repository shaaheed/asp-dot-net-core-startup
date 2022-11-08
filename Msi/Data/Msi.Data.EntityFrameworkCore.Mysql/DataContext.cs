using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore.MySql
{
    public class DataContext : DataContextBase
    {
        public DataContext(IOptions<DataContextOptions> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);

            if (string.IsNullOrEmpty(MigrationsAssembly))
            {
                optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
            }
            else
            {
                optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString),  options =>
                {
                    options.MigrationsAssembly(MigrationsAssembly);
                });
            }
        }
    }
}
