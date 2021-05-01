using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;

namespace Module.Sales.Domain
{
    public class DeleteInvoicePaymentCommandHandler : ICommandHandler<DeleteInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public DeleteInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<long> Handle(DeleteInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            var invoicePaymentRepo = _unitOfWork.GetRepository<InvoicePayment>();
            var invoicePayments = invoicePaymentRepo
                .Where(x => x.InvoiceId == request.InvoiceId && x.Id == request.Id);

            var paymentIds = invoicePayments.Select(x => x.PaymentId).ToList();
            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payments = paymentRepo.Where(x => paymentIds.Contains(x.Id));
           
            paymentRepo.RemoveRange(payments);
            invoicePaymentRepo.RemoveRange(invoicePayments);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _invoiceService.AddPayment(request.InvoiceId);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
