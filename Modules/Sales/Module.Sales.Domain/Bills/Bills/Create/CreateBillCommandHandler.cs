using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;

        public CreateBillCommandHandler(
            IUnitOfWork unitOfWork,
            IProductService productService,
            IBillService billService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _billService = billService;
            _contactService = contactService;
        }

        public async Task<long> Handle(CreateBillCommand request, CancellationToken cancellationToken)
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
            var billRepo = _unitOfWork.GetRepository<Bill>();
            var newBill = request.Map();

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            var newBillLineItems = request.Items.Select(x => new BillLineItem
            {
                Bill = newBill,
                LineItem = x.Map()
            });

            newBill.BillLineItems = newBillLineItems.ToList();
            await billRepo.AddAsync(newBill, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            _billService.Calculate(newBill);
            _billService.AddPayment(newBill);

            foreach (var savedProduct in savedProducts)
            {
                if (!savedProduct.IsSale || savedProduct.IsDeleted) throw new ValidationException($"{savedProduct.Name} is not salable.");

                if (savedProduct.IsInventory)
                {
                    var quantityToBuy = request.Items
                        .Where(x => x.ProductId == savedProduct.Id)
                        .Select(x => x.Quantity)
                        .Sum();

                    result += await _productService.IncreaseStockQuantityWithInventoryAdjustment(request.Number, InventoryAdjustmentType.Billed, savedProduct.Id, quantityToBuy, cancellationToken);
                }
            }
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            decimal payablesAmount = _billService.GetPayablesAmount(request.ContactId);
            await _contactService.UpdateDueAmount(request.ContactId, payablesAmount, cancellationToken);
            return result;
        }
    }
}
