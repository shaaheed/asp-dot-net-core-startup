using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommandHandler : ICommandHandler<UpdateInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IContactService _contactService;

        public UpdateInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _contactService = contactService;
        }

        public async Task<long> Handle(UpdateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            var invoicePaymentRepo = _unitOfWork.GetRepository<InvoicePayment>();
            var payment = invoicePaymentRepo
                .Where(x => x.InvoiceId == request.InvoiceId && x.Id == request.Id)
                .Select(x => x.Payment)
                .FirstOrDefault();

            if (payment == null)
                throw new NotFoundException("Invoice payment not found");

            request.Map(payment);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _invoiceService.AddPayment(request.InvoiceId);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            Guid? customerId = _invoiceService.GetCustomerId(request.InvoiceId);
            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(customerId);
            await _contactService.UpdateBalance(customerId, receivablesAmount, cancellationToken);

            return result;
        }
    }
}
