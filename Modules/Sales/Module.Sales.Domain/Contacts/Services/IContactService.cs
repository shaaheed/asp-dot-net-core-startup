using Msi.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IContactService : IScopedService
    {
        Task UpdateBalance(Guid? contactId, decimal amount, CancellationToken cancellationToken = default);
    }
}
