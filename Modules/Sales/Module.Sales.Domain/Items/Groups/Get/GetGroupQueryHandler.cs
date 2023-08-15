using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Items
{
    public class GetGroupQueryHandler : IQueryHandler<GetGroupQuery, GroupDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetGroupQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<GroupDto> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, GroupDto.Selector(), cancellationToken);
        }
    }
}
