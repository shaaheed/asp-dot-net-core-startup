using Core.Infrastructure.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Core.Domain;

namespace Module.Sales.Domain.Products
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.GetRepository<Entities.Product>()
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
                .FirstOrDefault(x => x.Id == request.Id);
            return await Task.FromResult(product);
        }
    }
}
