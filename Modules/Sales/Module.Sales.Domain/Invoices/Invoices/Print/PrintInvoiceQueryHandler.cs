using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.View.Abstraction;
using Module.Organizations.Entities;
using System;

namespace Module.Sales.Domain
{
    public class PrintInvoiceQueryHandler : IQueryHandler<PrintInvoiceQuery, string>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IViewRenderer _viewRenderer;
        private readonly IDocumentService _documentService;

        public PrintInvoiceQueryHandler(
            IUnitOfWork unitOfWork,
            IViewRenderer viewRenderer,
            IDocumentService documentService)
        {
            _unitOfWork = unitOfWork;
            _viewRenderer = viewRenderer;
            _documentService = documentService;
        }

        public async Task<string> Handle(PrintInvoiceQuery request, CancellationToken cancellationToken)
        {
            var paymentAmount = _documentService.GetPaymentsAmount(request.Id, cancellationToken);
            var invoice = await _unitOfWork.GetAsync(x => x.Id == request.Id, InvoicePrintDto.Selector(paymentAmount), cancellationToken);

            var organization = new InvoiceOrganizationPrintDto
            {
                Name = "আলমগীর এন্ড ব্রাদার্স",
                Address = "রামপুর বাজার, কালিহাতী, টাঙ্গাইল",
                Mobile = "০১৮১৫০০১২৪৫",
                Email = "alamgribrother@gmail.com"
            };

            if (invoice != null)
            {
                invoice.TopTextLine = "বিসমিল্লাহির রাহমানির রাহিম।";
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

                bool isPositiveAdjustment = invoice.AdjustmentAmount >= 0;
                invoice.AdjustmentAmountText = isPositiveAdjustment ? $"+{invoice.AdjustmentAmount}" : invoice.AdjustmentAmount.ToString();

                invoice.ThankyouMessage = "আমাদের সাথে কেনাকাটা করার জন্য আপনাকে ধন্যবাদ।";
                invoice.ThankyouMessage2 = "আবার আসবেন ইনশাআল্লাহ।";
                invoice.PrintedOn = DateTime.Now.ToString("dddd, MMMM dd, yyyy, hh:mm:ss tt");
                invoice.SoftwareBy = "https://shaaheed.github.io/me";

                invoice.Currency = "৳";
                invoice.Organization = organization;
                var html = await _viewRenderer.RenderAsync("/Views/pos-invoice.cshtml", invoice);
                return html;
            }
            return null;
        }
    }
}
