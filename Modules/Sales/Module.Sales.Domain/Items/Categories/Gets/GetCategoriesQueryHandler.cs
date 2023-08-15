using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Sales.Domain.Items
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, PagedCollection<CategoryListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<CategoryListItemDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(CategoryListItemDto.Selector(), request.FilterOptions, cancellationToken);
        }
    }
}
