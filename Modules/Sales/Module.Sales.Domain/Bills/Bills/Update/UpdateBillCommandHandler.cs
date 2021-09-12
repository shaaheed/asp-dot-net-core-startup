using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System;

namespace Module.Sales.Domain.Bills
{
    public class UpdateBillCommandHandler : ICommandHandler<UpdateBillCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;
        private readonly ILineItemService _lineItemService;

        public UpdateBillCommandHandler(
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

        public async Task<long> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {

            var billRepo = _unitOfWork.GetRepository<Bill>();
            var bill = await billRepo.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (bill == null)
                throw new NotFoundException("Bill not found");

            Guid? billSupplierId = bill.SupplierId;
            Guid? requestSupplierId = request.ContactId;
            request.Map(bill);

            var result = await _lineItemService.UpdateAsync(LineItemType.Purchase, bill.Id, request.Items, cancellationToken);

            _billService.Calculate(bill);
            _billService.AddPayment(bill);

            if (false /*billPaymentAmount > bill.GrandTotal*/)
            {
                //Over paid.
                //TODO: Create credit note
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            // TODO: Calculate Supplier balance
            decimal payablesAmount = _billService.GetPayablesAmount(requestSupplierId);
            await _contactService.UpdateBalance(requestSupplierId, payablesAmount, cancellationToken);

            if (requestSupplierId != billSupplierId)
            {
                payablesAmount = _billService.GetPayablesAmount(billSupplierId);
                await _contactService.UpdateBalance(billSupplierId, payablesAmount, cancellationToken);
            }

            return result;
        }
    }
}
