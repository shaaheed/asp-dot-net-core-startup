using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System;

namespace Module.Sales.Domain
{
    public class UpdateInvoiceCommandHandler : ICommandHandler<UpdateInvoiceCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IContactService _contactService;

        public UpdateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _contactService = contactService;
        }

        public async Task<long> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {

            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (invoice == null)
                throw new NotFoundException("Invoice not found");

            Guid? invoiceCustomerId = invoice.CustomerId;
            Guid? requestCustomerId = request.ContactId;
            request.Map(invoice);

            var result = await _invoiceService.UpdateLineItemAsync(ItemTransactionType.Sale, invoice.Id, request.Items, cancellationToken);

            _invoiceService.Calculate(invoice);
            _invoiceService.AddPayment(invoice);

            if (false /*invoicePaymentAmount > invoice.GrandTotal*/)
            {
                //Over paid.
                //TODO: Create credit note
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(requestCustomerId);
            await _contactService.UpdateBalance(requestCustomerId, receivablesAmount, cancellationToken);

            if (requestCustomerId != invoiceCustomerId)
            {
                receivablesAmount = _invoiceService.GetReceivablesAmount(invoice.CustomerId);
                await _contactService.UpdateBalance(invoiceCustomerId, receivablesAmount, cancellationToken);
            }

            return result;
        }
    }
}
