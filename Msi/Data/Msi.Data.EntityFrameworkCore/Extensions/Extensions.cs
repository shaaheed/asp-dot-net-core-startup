using Msi.Data.Abstractions;
using System;

namespace Msi.Data.EntityFrameworkCore
{
    public static class Extensions
    {

        public static UnitOfWorkOptions UseEntityFrameworkCore(this UnitOfWorkOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            options.UnitOfWorkType = typeof(UnitOfWork);
            return options;
        }

    }
}
