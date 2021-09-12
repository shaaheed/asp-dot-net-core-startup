using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;
        private readonly ILineItemService _lineItemService;

        public CreateBillCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService billService,
            IContactService contactService,
            ILineItemService lineItemService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
            _contactService = contactService;
            _lineItemService = lineItemService;
        }

        public async Task<long> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var billRepo = _unitOfWork.GetRepository<Bill>();
            var newBill = request.Map();

            await billRepo.AddAsync(newBill, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            result += await _lineItemService.CreateAsync(LineItemType.Purchase, newBill.Id, request.Items, cancellationToken);

            _billService.Calculate(newBill);
            _billService.AddPayment(newBill);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            decimal payablesAmount = _billService.GetPayablesAmount(request.ContactId);
            await _contactService.UpdateBalance(request.ContactId, payablesAmount, cancellationToken);

            return result;
        }
    }
}
