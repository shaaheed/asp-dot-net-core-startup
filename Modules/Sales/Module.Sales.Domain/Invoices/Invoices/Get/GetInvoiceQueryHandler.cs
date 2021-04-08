using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System.Linq;

namespace Module.Sales.Domain
{
    public class GetInvoiceQueryHandler : IQueryHandler<GetInvoiceQuery, InvoiceDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoiceQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoicePaymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
                .Where(x => x.InvoiceId == request.Id)
                .Select(x => x.Payment.Amount)
                .Sum();
            return _unitOfWork.GetAsync(x => x.Id == request.Id, InvoiceDto.Selector(invoicePaymentAmount), cancellationToken);
        }
    }
}
