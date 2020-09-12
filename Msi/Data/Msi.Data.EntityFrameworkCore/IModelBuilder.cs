using Microsoft.EntityFrameworkCore;

namespace Msi.Data.EntityFrameworkCore
{
    public interface IModelBuilder
    {
        void Build(ModelBuilder modelbuilder);
    }
}
