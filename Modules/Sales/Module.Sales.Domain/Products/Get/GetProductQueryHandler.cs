using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

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

        public Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, ProductDto.Selector(), cancellationToken);
        }
    }
}
