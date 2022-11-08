namespace Msi.Data.Abstractions
{

    public sealed class UnitOfWorkAccessor
    {

        /// <summary>
        /// Returns current scoped instance of IUnitOfWork
        /// </summary>
        public static IUnitOfWork Instance => (IUnitOfWork)_serviceProviderFactory().GetService(typeof(IUnitOfWork));

        private static Func<IServiceProvider> _serviceProviderFactory;

        public static void AddServiceProvider(Func<IServiceProvider> serviceProviderFactory)
        {
            _serviceProviderFactory = serviceProviderFactory;
        }

    }
}
