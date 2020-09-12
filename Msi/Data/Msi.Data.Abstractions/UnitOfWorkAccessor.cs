using System;

namespace Msi.Data.Abstractions
{

    public sealed class UnitOfWorkAccessor
    {

        /// <summary>
        /// Returns current scoped instance of IUnitOfWork
        /// </summary>
        public static IUnitOfWork Instance => (IUnitOfWork)_serviceFactoryAccessor()(typeof(IUnitOfWork));

        private static Func<Func<Type, object>> _serviceFactoryAccessor;

        public static void Initialize(Func<Func<Type, object>> serviceFactoryAccessor)
        {
            _serviceFactoryAccessor = serviceFactoryAccessor;
        }

    }
}
