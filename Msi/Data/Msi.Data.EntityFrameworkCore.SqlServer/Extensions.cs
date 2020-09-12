using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore.SqlServer
{
    public static class Extensions
    {

        public static UnitOfWorkOptions UseSqlServer(this UnitOfWorkOptions options)
        {
            options.DataContextType = typeof(DataContext);
            return options;
        }

    }
}
