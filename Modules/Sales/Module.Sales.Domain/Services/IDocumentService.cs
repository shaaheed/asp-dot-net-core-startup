using Module.Payments.Domain;
using Module.Sales.Entities;
using Msi.Utilities.Filter;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public interface IDocumentService
    {
        abstract Task<int> OnLineItemQuantityIncreased(Guid productId, float quantity, CancellationToken cancellationToken = default);

        abstract Task<int> OnLineItemQuantityDecreased(Guid productId, float quantity, CancellationToken cancellationToken = default);

        Task<Guid?> AddDocument<TDocument>(TDocument document, List<LineItemRequestDto> requestLineItems, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task UpdateDocument<TDocument>(Guid documentId, InvoiceDocumentRequestDto<TDocument> documentRequest, List<LineItemRequestDto> lineItemsRequest, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument, new();

        Task DeleteDocument<TDocument>(Guid documentId, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task UpdateContactBalance<TDocument>(Guid? contactId, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task UpdateDocumentStatus<TDocument>(TDocument document, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task<int> AddLineItemsAsync(LineTransactionType transactionType, AbstractDocument document, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken);

        Task<int> UpdateLineItemsAsync(LineTransactionType transactionType, AbstractDocument document, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken);

        Task<int> DeleteLineItemAsync(LineTransactionType transactionType, Guid referenceId, CancellationToken cancellationToken);

        decimal GetDocumentDueAmountsOfAContact<TDocument>(Guid? contactId) where TDocument : InvoiceDocument;

        Task<Guid> AddPayment<TDocument>(CreatePaymentCommand command, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task<Guid> UpdatePayment<TDocument>(UpdatePaymentCommand command, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task<bool> DeletePayment<TDocument>(DeletePaymentCommand command, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument;

        Task<PaymentDetailsDto> GetPayment(GetPaymentQuery query, CancellationToken cancellationToken = default);

        Task<PagedCollection<PaymentDetailsDto>> GetPayments(GetPaymentsQuery query, CancellationToken cancellationToken = default);

        decimal GetPaymentsAmount(Guid documentId, CancellationToken cancellationToken = default);

        decimal GetPaymentsAmount(Guid documentId, Guid contactId, CancellationToken cancellationToken = default);
    }
}
