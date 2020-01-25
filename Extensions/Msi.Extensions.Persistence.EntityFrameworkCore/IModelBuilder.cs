using Microsoft.EntityFrameworkCore;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public interface IModelBuilder
    {
        void Build(ModelBuilder modelbuilder);
    }
}
