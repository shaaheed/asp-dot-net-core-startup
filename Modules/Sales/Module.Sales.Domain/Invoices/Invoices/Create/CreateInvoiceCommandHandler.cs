using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;
        private readonly IContactService _contactService;
        private readonly ILineItemService _lineItemService;

        public CreateInvoiceCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService,
            IContactService contactService,
            ILineItemService lineItemService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _contactService = contactService;
            _lineItemService = lineItemService;
        }

        public async Task<long> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var newInvoice = request.Map();

            await invoiceRepo.AddAsync(newInvoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            result += await _lineItemService.CreateAsync(LineItemType.Sale, newInvoice.Id, request.Items, cancellationToken);

            _invoiceService.Calculate(newInvoice);
            _invoiceService.AddPayment(newInvoice);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            decimal receivablesAmount = _invoiceService.GetReceivablesAmount(request.ContactId);
            await _contactService.UpdateBalance(request.ContactId, receivablesAmount, cancellationToken);

            return result;
        }
    }
}
