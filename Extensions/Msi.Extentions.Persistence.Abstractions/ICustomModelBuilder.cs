using Microsoft.EntityFrameworkCore;

namespace Msi.Extensions.Persistence
{
    public interface ICustomModelBuilder
    {
        string DefaultSchema { get; }
        void Build(ModelBuilder modelBuilder);
    }
}
