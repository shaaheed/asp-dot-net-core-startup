using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using Module.Sales.Entities;

namespace Module.Sales.Domain
{
    public class CreateInvoicePaymentCommandHandler : ICommandHandler<CreateInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IContactService _contactService;

        public CreateInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _contactService = contactService;
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

            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(invoice.CustomerId);
            await _contactService.UpdateBalance(invoice.CustomerId, receivablesAmount, cancellationToken);

            return result;
        }
    }
}
