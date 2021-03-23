using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Invoices
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
            return _unitOfWork.GetAsync(x => x.Id == request.Id, InvoiceDto.Selector(), cancellationToken);
        }
    }
}
