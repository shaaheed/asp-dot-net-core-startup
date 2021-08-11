using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.View.Abstraction;
using Module.Organizations.Entities;

namespace Module.Sales.Domain
{
    public class PrintInvoiceQueryHandler : IQueryHandler<PrintInvoiceQuery, string>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IViewRenderer _viewRenderer;
        private readonly IInvoiceService _invoiceService;

        public PrintInvoiceQueryHandler(
            IUnitOfWork unitOfWork,
            IViewRenderer viewRenderer,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _viewRenderer = viewRenderer;
            _invoiceService = invoiceService;
        }

        public async Task<string> Handle(PrintInvoiceQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _invoiceService.GetPaymentAmount(request.Id);
            var invoice = await _unitOfWork.GetAsync(x => x.Id == request.Id, InvoicePrintDto.Selector(paymentAmount), cancellationToken);

            var organization = new InvoiceOrganizationPrintDto
            {
                Name = "আলমগীর এন্ড ব্রাদার্স",
                Address = "রামপুর বাজার, কালিহাতী, টাঙ্গাইল",
                Mobile = "০১৮১৫০০১২৪৫",
                Email = "alamgribrother@gmail.com"
            };
            if (invoice.Organization != null)
            {
                organization = await _unitOfWork.GetAsync<Organization, InvoiceOrganizationPrintDto>(x => x.Id == invoice.Organization.Id, x => new InvoiceOrganizationPrintDto
                {
                    Id = x.Id,
                    Address = x.AddressId != null ? x.Address.AddressLine1 : "",
                    Mobile = x.Address.Phone,
                    Email = x.Email,
                    Name = x.Name
                }, cancellationToken);

            }
            if (invoice != null)
            {
                invoice.Currency = "৳";
                invoice.Organization = organization;
                var html = await _viewRenderer.RenderAsync("/Views/pos-invoice.cshtml", invoice);
                return html;
            }
            return null;
        }
    }
}
