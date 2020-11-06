using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using System.Linq;

namespace Module.Sales.Domain.InvoicePayments
{
    public class CreateInvoicePaymentCommandHandler : ICommandHandler<CreateInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {

            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payment = new Payment
            {
                Amount = request.Amount,
                PaymentDate = request.PaymentDate,
                PaymentMethodId = request.PaymentMethodId,
                Memo = request.Memo,
                Reference = request.Reference
            };
            await paymentRepo.AddAsync(payment);
            int result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var invoicePaymentRepo = _unitOfWork.GetRepository<InvoicePayment>();
            var invoicePayment = new InvoicePayment
            {
                PaymentId = payment.Id,
                InvoiceId = request.InvoiceId
            };

            await invoicePaymentRepo.AddAsync(invoicePayment);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var invoice = await _unitOfWork.GetRepository<Invoice>()
                .FirstOrDefaultAsync(x => x.Id == request.InvoiceId);

            var invoicePaymentAmount = _unitOfWork.GetRepository<InvoicePayment>()
                .Where(x => x.InvoiceId == invoice.Id)
                .Select(x => x.Payment.Amount)
                .Sum();

            invoice.AddPayment(invoicePaymentAmount);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
