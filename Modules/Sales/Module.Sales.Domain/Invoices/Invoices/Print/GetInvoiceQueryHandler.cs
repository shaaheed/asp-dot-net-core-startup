using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.View.Abstraction;

namespace Module.Sales.Domain
{
    public class PrintInvoiceQueryHandler : IQueryHandler<PrintInvoiceQuery, string>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IViewRenderer _viewRenderer;

        public PrintInvoiceQueryHandler(
            IUnitOfWork unitOfWork,
            IViewRenderer viewRenderer)
        {
            _unitOfWork = unitOfWork;
            _viewRenderer = viewRenderer;
        }

        public async Task<string> Handle(PrintInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _unitOfWork.GetAsync(x => x.Id == request.Id, InvoicePrintDto.Selector(), cancellationToken);

            if (invoice != null)
            {
                invoice.Currency = "৳";
                invoice.Organization = new InvoiceOrganizationPrintDto
                {
                    Name = "আলমগীর এন্ড ব্রাদার্স",
                    Address = "রামপুর বাজার, কালিহাতী, টাঙ্গাইল",
                    Mobile = "০১৮১৫০০১২৪৫",
                    Email = "alamgribrother@gmail.com"
                };
                var html = await _viewRenderer.RenderAsync("/Views/pos-invoice.cshtml", invoice);
                return html;
            }
            return null;
        }
    }
}
