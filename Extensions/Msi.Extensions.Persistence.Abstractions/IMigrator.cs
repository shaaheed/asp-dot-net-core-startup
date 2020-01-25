using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence.Abstractions
{
    public interface IMigrator
    {
        Task MigratorAsync(IDataContext dataContext, CancellationToken cancellationToken = default);
    }
}
