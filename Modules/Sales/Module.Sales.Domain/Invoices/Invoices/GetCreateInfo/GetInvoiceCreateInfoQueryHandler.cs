using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Domain.Services;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoiceCreateInfoQueryHandler : IQueryHandler<GetInvoiceCreateInfoQuery, InvoiceCreateInfoDto>
    {

        private readonly IInvoiceService _invoiceService;

        public GetInvoiceCreateInfoQueryHandler(
            IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task<InvoiceCreateInfoDto> Handle(GetInvoiceCreateInfoQuery request, CancellationToken cancellationToken)
        {
            var info = new InvoiceCreateInfoDto {
                NextInvoiceNumber = _invoiceService.GetNextInvoiceNumber()
            };
            return Task.FromResult(info);
        }
    }
}
