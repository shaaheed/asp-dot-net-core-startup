using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore
{
    public static class Extensions
    {

        public static UnitOfWorkOptions UseEntityFrameworkCore(this UnitOfWorkOptions options)
        {
            options.UnitOfWorkType = typeof(UnitOfWork);
            return options;
        }

    }
}
