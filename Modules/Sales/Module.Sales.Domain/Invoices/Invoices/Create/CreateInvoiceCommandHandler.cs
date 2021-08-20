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
        private readonly IContactService _contactService;

        public CreateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IProductService productService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _productService = productService;
            _contactService = contactService;
        }

        public async Task<long> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var productRepo = _unitOfWork.GetRepository<Product>();
            var requestProductIds = request.Items
                .Where(x => x.ProductId != null)
                .Select(x => x.ProductId.Value)
                .ToList();

            await _productService.CheckDuplicate(requestProductIds, cancellationToken);

            var savedProducts = await _productService.GetSavedProducts(requestProductIds, cancellationToken);
            _productService.CheckProductNotFound(savedProducts);

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
                if (!savedProduct.IsSale || savedProduct.IsDeleted)
                    throw new ValidationException($"{savedProduct.Name} is not salable.");

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

            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(request.ContactId);
            await _contactService.UpdateDueAmount(request.ContactId, receivablesAmount, cancellationToken);

            return result;
        }
    }
}
