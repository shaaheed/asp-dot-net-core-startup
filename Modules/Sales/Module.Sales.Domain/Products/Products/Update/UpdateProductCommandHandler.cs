using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;
using System.Collections.Generic;
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
            var entity = await _unitOfWork.GetRepository<Product>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                request.Map(entity);
                await _unitOfWork.GetRepository<ProductCategory>()
                    .UpdateAsync(
                    request.Categories,
                    x => x.ProductId == entity.Id,
                    x => x.CategoryId,
                    x => new ProductCategory
                    {
                        ProductId = entity.Id,
                        CategoryId = x,
                    },
                    ids => x => ids.Contains(x.CategoryId) && x.ProductId == entity.Id);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
