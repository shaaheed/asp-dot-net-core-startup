using Module.Payments.Domain;
using Module.Sales.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public abstract class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IPaymentService _paymentService;
        private readonly IContactService _contactService;
        private readonly IRepository<LineItem> _lineItemRepo;

        public DocumentService(
            IUnitOfWork unitOfWork,
            IProductService productService,
            IContactService contactService,
            IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _paymentService = paymentService;
            _contactService = contactService;
            _lineItemRepo = _unitOfWork.GetRepository<LineItem>();
        }

        public virtual Task<int> OnLineItemQuantityIncreased(Guid productId, float quantity, CancellationToken cancellationToken = default)
        {
            // stock will be increase as product has come into system
            return _productService.IncreaseStockQuantity(productId, quantity, cancellationToken);
        }

        public virtual Task<int> OnLineItemQuantityDecreased(Guid productId, float quantity, CancellationToken cancellationToken = default)
        {
            // stock will be decrease as product has gone from system
            return _productService.DecreaseStockQuantity(productId, quantity, cancellationToken);
        }

        public async Task<Guid?> AddDocument<TDocument>(TDocument document, List<LineItemRequestDto> requestLineItems, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            if (document == null) return null;

            // add document.
            await _unitOfWork.GetRepository<TDocument>().AddAsync(document, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // add line items.
            await AddLineItemsAsync(transactionType, document, requestLineItems, cancellationToken);

            // calculate document total, subtotal, grand total etc.
            await Calculate(document, transactionType);

            // update contact balance
            await UpdateContactBalance<TDocument>(document.ContactId, cancellationToken);

            return document.Id;
        }

        public async Task UpdateDocument<TDocument>(Guid documentId, InvoiceDocumentRequestDto<TDocument> documentRequest, List<LineItemRequestDto> lineItemsRequest, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument, new()
        {
            var document = await _unitOfWork.GetRepository<TDocument>()
                .FirstOrDefaultAsync(x => x.Id == documentId && !x.IsDeleted);

            if (document == null)
                throw new NotFoundException("Document not found");

            Guid? documentContactId = document.ContactId;
            Guid? requestContactId = documentRequest.ContactId;

            // update document.
            documentRequest.Map(document);

            // update line items
            var result = await UpdateLineItemsAsync(transactionType, document, lineItemsRequest, cancellationToken);

            // calculate document total, subtotal, grand total etc.
            await Calculate(document, transactionType, cancellationToken);

            // update contact balance
            await UpdateContactBalance<TDocument>(requestContactId, cancellationToken);
            if (requestContactId != documentContactId)
            {
                await UpdateContactBalance<TDocument>(documentContactId, cancellationToken);
            }
        }

        public async Task DeleteDocument<TDocument>(Guid documentId, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            var documentRepo = _unitOfWork.GetRepository<TDocument>();
            var document = await documentRepo.FirstOrDefaultAsync(x => x.Id == documentId, cancellationToken);

            if (document == null)
                throw new ValidationException("Document not found.");

            var result = await DeleteLineItemAsync(transactionType, documentId, cancellationToken);

            documentRepo.Remove(document);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            //var allowedStatuses = new List<Status> { Status.Due };
            //if (result > 0 && allowedStatuses.Contains(bill.Status))
            //{
            //    // decrease product stock as bill has been deleted.
            //    var savedLineItemsHasProduct = savedBillLineItems.Where(x => x.ProductId.HasValue);
            //    foreach (var savedBillLineItem in savedLineItemsHasProduct)
            //    {
            //        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, savedBillLineItem.ProductId.Value, savedBillLineItem.LineItemQuantity, cancellationToken);
            //    }
            //}

            await UpdateContactBalance<TDocument>(document.ContactId, cancellationToken);
        }

        public Task UpdateContactBalance<TDocument>(Guid? contactId, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            var amount = GetDocumentDueAmountsOfAContact<TDocument>(contactId);
            return _contactService.UpdateBalance(contactId, amount, cancellationToken);
        }

        public async Task UpdateDocumentStatus<TDocument>(TDocument document, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            var paymentsAmount = _paymentService.GetPaymentsAmount(document.Id);
            if (document.GrandTotal == paymentsAmount)
            {
                // Full payment
                document.Status = Status.Paid;
                document.AmountDue = 0;
            }
            else if (document.GrandTotal > paymentsAmount)
            {
                // Partial or no payment
                document.Status = Status.Due;
            }

            if (paymentsAmount <= document.GrandTotal)
            {
                document.AmountDue = document.GrandTotal - paymentsAmount;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> AddLineItemsAsync(LineTransactionType transactionType, AbstractDocument document, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken)
        {
            int result = 0;
            var requestProductIds = requestLineItems
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();

            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

            var newLineItems = requestLineItems.Select(x =>
            {
                LineItem newLineItem = x.Map();
                newLineItem.TransactionType = transactionType;
                newLineItem.DocumentId = document.Id;
                newLineItem.DocumentName = document.Number;
                newLineItem.ContactId = document.ContactId;
                return newLineItem;
            });

            await _lineItemRepo.AddRangeAsync(newLineItems);
            foreach (var savedProduct in savedProducts)
            {
                // if (!savedProduct.IsSale || savedProduct.IsDeleted) throw new ValidationException($"{savedProduct.Name} is not salable.");
                if (savedProduct.IsInventory)
                {
                    var quantity = requestLineItems
                        .Where(x => x.ProductId == savedProduct.Id)
                        .Select(x => x.Quantity)
                        .Sum();

                    result += await OnLineItemQuantityIncreased(savedProduct.Id, quantity, cancellationToken);
                }
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<int> UpdateLineItemsAsync(LineTransactionType transactionType, AbstractDocument document, List<LineItemRequestDto> requestLineItems, CancellationToken cancellationToken)
        {
            var requestProductIds = requestLineItems
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();
            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

            var savedLineItems = await _lineItemRepo
                .ListAsyncAsReadOnly(x => x.DocumentId == document.Id && x.TransactionType == transactionType && !x.IsDeleted, x => new
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    LineItemQuantity = x.Quantity
                }, cancellationToken);

            var result = 0;
            foreach (var requestLineItem in requestLineItems)
            {
                if (requestLineItem.Id.HasValue)
                {
                    // line item will be update
                    var savedLineItem = savedLineItems.FirstOrDefault(x => x.Id == requestLineItem.Id);

                    if (savedLineItem == null)
                        throw new ValidationException("Line item not found");

                    result += await CreateOrUpdateLineItemInternal(requestLineItem, transactionType, document, cancellationToken);

                    // line item product changed
                    if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value != savedLineItem.ProductId.Value)
                    {
                        // new product added to line item
                        result += await OnLineItemQuantityIncreased(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);

                        // old prodcut removed from line item
                        result += await OnLineItemQuantityDecreased(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }

                    // line item product not changed but quantiy may changed
                    else if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value == savedLineItem.ProductId.Value)
                    {
                        if (requestLineItem.Quantity > savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be increase
                            var quantity = requestLineItem.Quantity - savedLineItem.LineItemQuantity;

                            result += await OnLineItemQuantityIncreased(requestLineItem.ProductId.Value, quantity, cancellationToken);
                        }
                        else if (requestLineItem.Quantity < savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be decrease
                            var quantity = savedLineItem.LineItemQuantity - requestLineItem.Quantity;
                            result += await OnLineItemQuantityDecreased(requestLineItem.ProductId.Value, quantity, cancellationToken);
                        }
                    }

                    else if (requestLineItem.ProductId.HasValue && !savedLineItem.ProductId.HasValue)
                    {
                        // new product added to line item
                        // product stock quantity will be increase
                        result += await OnLineItemQuantityIncreased(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    else if (!requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue)
                    {
                        // product removed from line item
                        // product stock quantity will be decrease
                        result += await OnLineItemQuantityDecreased(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
                else
                {
                    if (requestLineItem.ProductId.HasValue)
                    {
                        await _productService.CheckProductSelable(requestLineItem.ProductId, requestLineItem.Name, cancellationToken);

                        result += await OnLineItemQuantityIncreased(requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    result += await CreateOrUpdateLineItemInternal(requestLineItem, transactionType, document, cancellationToken);
                }
            }

            var deletedLineItems = new List<LineItem>();
            foreach (var savedLineItem in savedLineItems)
            {
                var requestItem = requestLineItems.FirstOrDefault(x => x.Id == savedLineItem.Id);
                if (requestItem == null)
                {
                    // delete saved item
                    deletedLineItems.Add(new LineItem { Id = savedLineItem.Id });

                    // decrease product stock as product line item is deleted
                    if (savedLineItem.ProductId.HasValue)
                    {
                        result += await OnLineItemQuantityDecreased(savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
            }

            _lineItemRepo.RemoveRange(deletedLineItems);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteLineItemAsync(LineTransactionType transactionType, Guid documentId, CancellationToken cancellationToken)
        {
            var savedLineItems = await _lineItemRepo.ListAsyncAsReadOnly(x => x.TransactionType == transactionType && x.DocumentId == documentId, x => new LineItem
            { Id = x.Id }, cancellationToken);

            _lineItemRepo.RemoveRange(savedLineItems);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Get specific Customer or Supplier total due amount.
        /// </summary>
        public decimal GetDocumentDueAmountsOfAContact<TDocument>(Guid? contactId) where TDocument : InvoiceDocument
        {
            if (contactId == null) return 0;
            return _unitOfWork.GetRepository<TDocument>()
                .WhereAsReadOnly(x => x.ContactId == contactId && x.AmountDue > 0 && !x.IsDeleted)
                .Select(x => x.AmountDue)
                .Sum();
        }

        public async Task<Guid> AddPayment<TDocument>(CreatePaymentCommand command, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            var document = await _unitOfWork.GetRepository<TDocument>()
                .FirstOrDefaultAsync(x => x.Id == command.DocumentId && !x.IsDeleted);

            if (document == null)
                throw new NotFoundException("Document not found");

            command.DocumentName = document.Number;
            command.CustomerId = document.ContactId;
            command.CustomerName = document.Contact.DisplayName;

            if (command.CurrencyId == null)
            {
                command.CurrencyId = document.CurrencyId;
                command.CurrencyExchangeRate = document.CurrencyExchangeRate;
            }

            var paymentId = await _paymentService.Create(command, cancellationToken);

            await UpdateDocumentStatus(document, cancellationToken);
            await UpdateContactBalance<TDocument>(document.ContactId, cancellationToken);

            return paymentId;
        }

        public async Task<Guid> UpdatePayment<TDocument>(UpdatePaymentCommand command, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            var document = await _unitOfWork.GetRepository<TDocument>()
                .FirstOrDefaultAsync(x => x.Id == command.DocumentId && !x.IsDeleted);

            if (document == null)
                throw new NotFoundException("Document not found");

            command.DocumentName = document.Number;
            command.CustomerId = document.ContactId;
            command.CustomerName = document.Contact.DisplayName;

            if (command.CurrencyId == null)
            {
                command.CurrencyId = document.CurrencyId;
                command.CurrencyExchangeRate = document.CurrencyExchangeRate;
            }

            var paymentId = await _paymentService.Update(command, cancellationToken);

            await UpdateDocumentStatus(document, cancellationToken);
            await UpdateContactBalance<TDocument>(document.ContactId, cancellationToken);

            return paymentId;
        }

        public async Task<bool> DeletePayment<TDocument>(DeletePaymentCommand command, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            var document = await _unitOfWork.GetRepository<TDocument>()
                .FirstOrDefaultAsync(x => x.Id == command.DocumentId && !x.IsDeleted);

            if (document == null)
                throw new NotFoundException("Document not found");

            var deleted = await _paymentService.Delete(command, cancellationToken);

            await UpdateDocumentStatus(document, cancellationToken);
            await UpdateContactBalance<TDocument>(document.ContactId, cancellationToken);

            return deleted;
        }

        public Task<PaymentDetailsDto> GetPayment(GetPaymentQuery query, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GetAsync(x => x.Id == query.Id && x.DocumentId == query.DocumentId, PaymentDetailsDto.Selector(), cancellationToken);
        }

        public Task<PagedCollection<PaymentDetailsDto>> GetPayments(GetPaymentsQuery query, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.ListAsync(x => x.DocumentId == query.DocumentId, PaymentDetailsDto.Selector(), query.FilterOptions, cancellationToken);
        }

        public decimal GetPaymentsAmount(Guid documentId, CancellationToken cancellationToken = default)
        {
            return _paymentService.GetPaymentsAmount(documentId, cancellationToken);
        }

        public decimal GetPaymentsAmount(Guid documentId, Guid contactId, CancellationToken cancellationToken = default)
        {
            return _paymentService.GetPaymentsAmount(documentId, contactId, cancellationToken);
        }

        /// <summary>
        /// Calculate document's Total, Subtoal, Grandtotal etc.
        /// </summary>
        public async Task Calculate<TDocument>(TDocument document, LineTransactionType transactionType, CancellationToken cancellationToken = default) where TDocument : InvoiceDocument
        {
            if (document != null)
            {
                decimal grandTotal = 0;
                decimal subtotal = 0;
                var lineItems = _lineItemRepo
                    .WhereAsReadOnly(x => x.DocumentId == document.Id && x.TransactionType == transactionType && !x.IsDeleted && x.LineType == LineType.Transaction)
                    .Select(x => new
                    {
                        Total = x.Total,
                        Subtotal = x.Subtotal
                    });
                foreach (var item in lineItems)
                {
                    grandTotal += item.Total;
                    subtotal += item.Subtotal;
                }
                grandTotal += document.AdjustmentAmount;
                document.GrandTotal = grandTotal;
                document.Subtotal = subtotal;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task<int> CreateOrUpdateLineItemInternal(
            LineItemRequestDto request,
            LineTransactionType transactionType,
            AbstractDocument document,
            CancellationToken cancellationToken = default)
        {
            var lineItem = new LineItem();
            if (request.Id.HasValue)
            {
                var savedLineItem = await _unitOfWork
                    .GetRepository<LineItem>()
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == request.Id.Value && x.DocumentId == document.Id && x.TransactionType == transactionType && !x.IsDeleted, x => new { Id = x.Id }, cancellationToken);

                if (savedLineItem == null)
                    throw new ValidationException("Line item not found.");

                lineItem.Id = request.Id.Value;
                _lineItemRepo.Attach(lineItem);
                lineItem.DocumentName = document.Number;
                lineItem.ContactId = document.ContactId;
                request.Map(lineItem);
            }
            else
            {
                request.Map(lineItem);
                lineItem.TransactionType = transactionType;
                lineItem.DocumentId = document.Id;
                lineItem.DocumentName = document.Number;
                lineItem.ContactId = document.ContactId;
                await _lineItemRepo.AddAsync(lineItem, cancellationToken);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

    }
}
