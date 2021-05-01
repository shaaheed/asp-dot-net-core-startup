using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;

namespace Module.Sales.Domain
{
    public class GetInvoicePaymentQueryHandler : IQueryHandler<GetInvoicePaymentQuery, InvoicePaymentDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicePaymentQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<InvoicePaymentDto> Handle(GetInvoicePaymentQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, InvoicePaymentDto.Selector(), cancellationToken);
        }
    }
}
