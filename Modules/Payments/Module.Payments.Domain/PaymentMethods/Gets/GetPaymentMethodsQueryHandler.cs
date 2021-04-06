using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Payments.Domain
{
    public class GetPaymentMethodsQueryHandler : IQueryHandler<GetPaymentMethodsQuery, PagedCollection<PaymentMethodDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentMethodsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedCollection<PaymentMethodDto>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ListAsync(PaymentMethodDto.Selector(), request.PagingOptions, request.SearchOptions, cancellationToken);
        }
    }
}
