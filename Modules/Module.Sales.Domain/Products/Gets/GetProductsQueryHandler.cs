using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Core.Domain;

namespace Module.Sales.Domain.Products
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.GetRepository<Entities.Product>()
                .AsQueryable()
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Category = x.Category != null ? new IdNameDto<long>
                    {
                        Id = (long)x.CategoryId,
                        Name = x.Name
                    } : null,
                    Manufacturer = x.Manufacturer != null ? new IdNameDto<long>
                    {
                        Id = (long)x.ManufacturerId,
                        Name = x.Name
                    } : null,
                    UnitOfMeasurement = x.UnitOfMeasurement != null ? new IdNameDto<long>
                    {
                        Id = (long)x.UnitOfMeasurementId,
                        Name = x.Name
                    } : null,
                    Description = x.Description,
                    Price = x.Price,
                    IsBuy = x.IsBuy,
                    IsSale = x.IsSale,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    SupportStartDate = x.SupportStartDate,
                    SupportEndDate = x.SupportEndDate
                })
                .ToList();
            return await Task.FromResult(products);
        }
    }
}
