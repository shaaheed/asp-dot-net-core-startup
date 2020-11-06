using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Msi.Core;
using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore.SqlServer
{
    public class DataContext : DataContextBase
    {
        private readonly static ILoggerFactory _loggerFacroty = LoggerFactory.Create(builder => builder.AddConsole());

        public DataContext(IOptions<DataContextOptions> options) : base(options)
        {

        }

        public DataContext(DataContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var env = Global.Environment;
            if (!string.IsNullOrEmpty(env) && env.Equals("Development"))
            {
                optionsBuilder.EnableSensitiveDataLogging();
                if (_loggerFacroty != null)
                {
                    optionsBuilder.UseLoggerFactory(_loggerFacroty);
                }
            }

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
