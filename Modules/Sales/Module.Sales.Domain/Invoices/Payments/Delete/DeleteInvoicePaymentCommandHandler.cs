using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using System;

namespace Module.Sales.Domain
{
    public class DeleteInvoicePaymentCommandHandler : ICommandHandler<DeleteInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IContactService _contactService;

        public DeleteInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _contactService = contactService;
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

            Guid? customerId = _invoiceService.GetCustomerId(request.InvoiceId);
            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(customerId);
            await _contactService.UpdateDueAmount(customerId, receivablesAmount, cancellationToken);

            return result;
        }
    }
}
