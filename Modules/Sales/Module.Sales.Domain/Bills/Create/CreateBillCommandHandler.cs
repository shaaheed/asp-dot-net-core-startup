using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain.Bills
{
    public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public CreateBillCommandHandler(
            IUnitOfWork unitOfWork,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<long> Handle(CreateBillCommand request, CancellationToken cancellationToken)
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
            var billRepo = _unitOfWork.GetRepository<Bill>();
            var newBill = request.Map();

            await billRepo.AddAsync(newBill, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
