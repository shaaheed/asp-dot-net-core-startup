using Microsoft.EntityFrameworkCore;
using Msi.Data.Abstractions;

namespace Msi.Data.EntityFrameworkCore
{
    public static class DataContextExtensions
    {
        public static void BuildModels(this IDataContext dataContext, ModelBuilder modelBuilder)
        {
            //var builders = ExtensionManager.GetInstances<IModelBuilder>();
            //foreach (IModelBuilder builder in builders)
            //{
            //    builder.Build(modelBuilder);
            //}
            //modelBuilder.Seeds();
        }
    }
}
