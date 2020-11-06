using System;

namespace Msi.Data.Abstractions
{
    public class UnitOfWorkOptions
    {
        public Type UnitOfWorkType { get; set; }
        public Type DataContextType { get; set; }
        public string MigrationAssembly { get; set; }
    }
}
