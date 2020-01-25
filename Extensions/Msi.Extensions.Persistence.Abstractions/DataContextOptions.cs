namespace Msi.Extensions.Persistence.Abstractions
{
    public class DataContextOptions
    {
        public virtual string ConnectionString { get; set; }
        public virtual string MigrationsAssembly { get; set; }
    }
}
