using Microsoft.EntityFrameworkCore;
using Msi.Extensions.Persistence.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Extensions.Persistence.EntityFrameworkCore
{
    public class MigratorBase : IMigrator
    {
        public async Task MigratorAsync(IDataContext dataContext, CancellationToken cancellationToken = default)
        {
            await (dataContext as DbContext)?.Database.EnsureCreatedAsync(cancellationToken);
        }
    }
}
