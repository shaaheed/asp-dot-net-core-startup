using Module.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface ISalesService
    {
        abstract Task<int> OnLineItemQuantityIncreased(Guid productId, float quantity, CancellationToken cancellationToken = default);

        Task<int> CreateLineItemAsync(ItemTransactionType lineItemType, Guid referenceId, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken);

        Task<int> UpdateLineItemAsync(ItemTransactionType lineItemType, Guid referenceId, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken);

        Task<int> DeleteLineItemAsync(ItemTransactionType lineItemType, Guid referenceId, CancellationToken cancellationToken);

        Task<int> CreateOrUpdateLineItem(LineItemRequestDto request, ItemTransactionType type, Guid referenceId, CancellationToken cancellationToken = default);
    }
}
