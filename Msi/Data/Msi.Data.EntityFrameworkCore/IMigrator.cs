using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.EntityFrameworkCore
{
    public interface IMigrator
    {
        Task MigratorAsync(IDataContext dataContext, CancellationToken cancellationToken = default);
    }
}
