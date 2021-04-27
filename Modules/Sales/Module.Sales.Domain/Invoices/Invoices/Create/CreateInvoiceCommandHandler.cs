using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;

        public CreateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _productService = productService;
        }

        public async Task<long> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.Items
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();

            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await productRepo
                .ListAsyncAsReadOnly(x => requestProductIds.Contains(x.Id), x => new
                {
                    Id = x.Id,
                    Quantity = x.StockQuantity,
                    Name = x.Name,
                    IsInventory = x.IsInventory,
                    IsSale = x.IsSale,
                    IsDeleted = x.IsDeleted
                }, cancellationToken);

            var notFoundProducts = savedProducts
                .Where(x => !requestProductIds.Contains(x.Id))
                .ToList();

            if (notFoundProducts.Count() > 0)
                throw new ValidationException($"{notFoundProducts[0].Name} not found.");

            int result = 0;
            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var newInvoice = request.Map();

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var newInvoiceLineItems = request.Items.Select(x => new InvoiceLineItem
            {
                Invoice = newInvoice,
                LineItem = x.Map()
            });

            newInvoice.InvoiceLineItems = newInvoiceLineItems.ToList();
            await invoiceRepo.AddAsync(newInvoice, cancellationToken);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            _invoiceService.Calculate(newInvoice);
            _invoiceService.AddPayment(newInvoice);

            foreach (var savedProduct in savedProducts)
            {
                if (!savedProduct.IsSale || savedProduct.IsDeleted) throw new ValidationException($"{savedProduct.Name} is not salable.");

                if (savedProduct.IsInventory)
                {
                    var quantityToBuy = request.Items
                        .Where(x => x.ProductId == savedProduct.Id)
                        .Select(x => x.Quantity)
                        .Sum();

                    result += await _productService.DecreaseStockQuantityWithInventoryAdjustment(request.Number, InventoryAdjustmentType.Invoiced, savedProduct.Id, quantityToBuy, cancellationToken);
                }
            }
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
