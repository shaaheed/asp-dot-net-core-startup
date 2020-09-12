using Microsoft.EntityFrameworkCore;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.EntityFrameworkCore
{
    public class MigratorBase : IMigrator
    {
        public async Task MigratorAsync(IDataContext dataContext, CancellationToken cancellationToken = default)
        {
            await (dataContext as DbContext)?.Database.EnsureCreatedAsync(cancellationToken);
        }
    }
}
