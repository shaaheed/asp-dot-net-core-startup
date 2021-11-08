using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Payments.Domain
{
    public class GetPaymentsQueryHandler : IQueryHandler<GetPaymentsQuery, PagedCollection<PaymentDetailsDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<PaymentDetailsDto>> Handle(GetPaymentsQuery query, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(x => x.DocumentId == query.DocumentId, PaymentDetailsDto.Selector(), query.FilterOptions, cancellationToken);
        }
    }
}
