using Module.Sales.Entities;
using Msi.Service;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface ILineItemService : IScopedService
    {
        Task<int> CreateAsync(LineItemType lineItemType, Guid referenceId, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken);

        Task<int> UpdateAsync(LineItemType lineItemType, Guid referenceId, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken);

        Task<int> DeleteAsync(LineItemType lineItemType, Guid referenceId, CancellationToken cancellationToken);

        Task<int> CreateOrUpdate(LineItemRequestDto request, LineItemType type, Guid referenceId, CancellationToken cancellationToken = default);
    }
}
