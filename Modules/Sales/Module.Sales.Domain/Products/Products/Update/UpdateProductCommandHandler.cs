using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;
using System;
using System.Linq;

namespace Module.Sales.Domain.Products
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<Item>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (item != null)
            {
                request.Map(item);
                await _unitOfWork.GetRepository<ItemCategory>()
                    .UpdateAsync(
                    request.Categories,
                    x => x.ItemId == item.Id,
                    x => x.CategoryId,
                    x => new ItemCategory
                    {
                        ItemId = item.Id,
                        CategoryId = x,
                    },
                    ids => x => ids.Contains(x.CategoryId) && x.ItemId == item.Id);

                if (request.SaleDetails != null)
                {
                    var saleRepo = _unitOfWork.GetRepository<SaleDetails>();
                    var saleDetails = await saleRepo.FirstOrDefaultAsync(x => x.ItemId == item.Id);
                    if (saleDetails != null)
                    {
                        request.SaleDetails?.Map(saleDetails);
                    }
                    else
                    {
                        await saleRepo.AddAsync(request.SaleDetails.Map(), cancellationToken);
                    }
                }

                if (request.PurchaseDetails != null)
                {
                    var purchaseRepo = _unitOfWork.GetRepository<PurchaseDetails>();
                    var purchaseDetails = await purchaseRepo.FirstOrDefaultAsync(x => x.ItemId == item.Id);
                    if (purchaseDetails != null)
                    {
                        request.PurchaseDetails?.Map(purchaseDetails);
                    }
                    else
                    {
                        await purchaseRepo.AddAsync(request.PurchaseDetails.Map(), cancellationToken);
                    }
                }

            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
