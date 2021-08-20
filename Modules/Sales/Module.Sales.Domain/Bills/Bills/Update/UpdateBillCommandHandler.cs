using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System.Collections.Generic;
using System;

namespace Module.Sales.Domain.Bills
{
    public class UpdateBillCommandHandler : ICommandHandler<UpdateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IProductService _productService;
        private readonly IContactService _contactService;

        public UpdateBillCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService billService,
            IProductService productService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
            _productService = productService;
            _contactService = contactService;
        }

        public async Task<long> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {

            var billRepo = _unitOfWork.GetRepository<Bill>();
            var bill = await billRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (bill == null)
                throw new NotFoundException("Bill not found");

            Guid? billSupplierId = bill.SupplierId;
            Guid? requestSupplierId = request.ContactId;
            request.Map(bill);

            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.Items
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();
            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

            var billLineItemsRepo = _unitOfWork.GetRepository<BillLineItem>();
            var billLineItems = new List<BillLineItem>();

            var savedBillLineItems = await billLineItemsRepo
                .ListAsyncAsReadOnly(x => x.BillId == bill.Id, x => new
                {
                    Id = x.Id,
                    LineItemId = x.LineItemId,
                    ProductId = x.LineItem.ProductId,
                    ProductName = x.LineItem.Product.Name,
                    LineItemQuantity = x.LineItem.Quantity
                }, cancellationToken);

            var inventoryAdjustmentLineItemRepo = _unitOfWork.GetRepository<InventoryAdjustmentLineItem>();
            var inventoryAdjustments = new List<InventoryAdjustmentLineItem>();
            var adjustedProducts = new List<Product>();

            var result = 0;
            foreach (var requestLineItem in request.Items)
            {
                if (requestLineItem.Id.HasValue)
                {
                    // update
                    var savedLineItem = savedBillLineItems.FirstOrDefault(x => x.Id == requestLineItem.Id);

                    if (savedLineItem == null)
                        throw new ValidationException("Line item not found");

                    result += await _billService.CreateOrUpdateBillLineItem(requestLineItem, bill.Id, savedLineItem.LineItemId, cancellationToken);

                    // bill line item product changed
                    if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value != savedLineItem.ProductId.Value)
                    {
                        // increasing product stock as new product is added to bill line item
                        result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);

                        // decreasing product stock as product is removed from bill line item
                        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }

                    // bill line item product not changed but quantiy may changed
                    else if (requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue && requestLineItem.ProductId.Value == savedLineItem.ProductId.Value)
                    {
                        if (requestLineItem.Quantity > savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be increase
                            var quantityToBeIncrease = requestLineItem.Quantity - savedLineItem.LineItemQuantity;
                            result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, requestLineItem.ProductId.Value, quantityToBeIncrease, cancellationToken);
                        }
                        else if (requestLineItem.Quantity < savedLineItem.LineItemQuantity)
                        {
                            // product stock quantity will be increase
                            var quantityToBeDecrease = savedLineItem.LineItemQuantity - requestLineItem.Quantity;
                            result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, requestLineItem.ProductId.Value, quantityToBeDecrease, cancellationToken);
                        }
                    }

                    else if (requestLineItem.ProductId.HasValue && !savedLineItem.ProductId.HasValue)
                    {
                        // new product added to bill line item
                        // product stock quantity will be increase
                        result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    else if (!requestLineItem.ProductId.HasValue && savedLineItem.ProductId.HasValue)
                    {
                        // product removed from bill line item
                        // product stock quantity will be decrease
                        result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
                else
                {
                    if (requestLineItem.ProductId.HasValue)
                    {
                        await _productService.CheckProductSelable(requestLineItem.ProductId, requestLineItem.Name, cancellationToken);

                        result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, requestLineItem.ProductId.Value, requestLineItem.Quantity, cancellationToken);
                    }

                    result += await _billService.CreateOrUpdateBillLineItem(requestLineItem, bill.Id, null, cancellationToken);
                }
            }

            var deletedBillLineItems = new List<BillLineItem>();
            var deletedLineItems = new List<LineItem>();
            foreach (var savedLineItem in savedBillLineItems)
            {
                var requestItem = request.Items.FirstOrDefault(x => x.Id == savedLineItem.Id);
                if (requestItem == null)
                {
                    // delete saved item
                    deletedBillLineItems.Add(new BillLineItem { Id = savedLineItem.Id });
                    deletedLineItems.Add(new LineItem { Id = savedLineItem.LineItemId });

                    // decrease product stock as product line item is deleted
                    if (savedLineItem.ProductId.HasValue)
                    {
                        await _productService.DecreaseStockQuantityWithInventoryAdjustment(bill.Number, InventoryAdjustmentType.Billed, savedLineItem.ProductId.Value, savedLineItem.LineItemQuantity, cancellationToken);
                    }
                }
            }

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(deletedLineItems);
            billLineItemsRepo.RemoveRange(deletedBillLineItems);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _billService.Calculate(bill);
            _billService.AddPayment(bill);

            if (false /*billPaymentAmount > bill.GrandTotal*/)
            {
                //Over paid.
                //TODO: Create credit note
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            decimal payablesAmount = _billService.GetPayablesAmount(requestSupplierId);
            await _contactService.UpdateDueAmount(requestSupplierId, payablesAmount, cancellationToken);

            if (requestSupplierId != billSupplierId)
            {
                payablesAmount = _billService.GetPayablesAmount(billSupplierId);
                await _contactService.UpdateDueAmount(requestSupplierId, payablesAmount, cancellationToken);
            }

            return result;
        }
    }
}
