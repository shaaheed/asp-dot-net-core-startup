using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Items
{
    public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, CategoryDto.Selector(), cancellationToken);
        }
    }
}
