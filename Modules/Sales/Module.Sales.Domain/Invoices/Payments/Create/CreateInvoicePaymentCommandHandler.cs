using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using Module.Sales.Entities;
using Module.Sales.Domain.Services;

namespace Module.Sales.Domain.InvoicePayments
{
    public class CreateInvoicePaymentCommandHandler : ICommandHandler<CreateInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public CreateInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<long> Handle(CreateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = request.Map();
            await _unitOfWork.GetRepository<Payment>().AddAsync(payment);
            int result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var invoicePayment = new InvoicePayment
            {
                PaymentId = payment.Id,
                InvoiceId = request.InvoiceId
            };

            await _unitOfWork.GetRepository<InvoicePayment>().AddAsync(invoicePayment);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var invoice = await _unitOfWork.GetRepository<Invoice>()
                .FirstOrDefaultAsync(x => x.Id == request.InvoiceId);
            _invoiceService.AddPayment(invoice);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
