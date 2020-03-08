using Microsoft.EntityFrameworkCore;
using Msi.Extensions.Infrastructure;
using Msi.Extensions.Persistence.Abstractions;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public static class DataContextExtensions
    {
        public static void BuildModels(this IDataContext dataContext, ModelBuilder modelBuilder)
        {
            var builders = ExtensionManager.GetInstances<IModelBuilder>();
            foreach (IModelBuilder builder in builders)
            {
                System.Console.WriteLine(builder.ToString());
                builder.Build(modelBuilder);
            }
        }
    }
}
