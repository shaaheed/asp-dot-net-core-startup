using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using Module.Sales.Entities;

namespace Module.Sales.Domain
{
    public class CreateBillPaymentCommandHandler : ICommandHandler<CreateBillPaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;

        public CreateBillPaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService billService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
            _contactService = contactService;
        }

        public async Task<long> Handle(CreateBillPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = request.Map();
            await _unitOfWork.GetRepository<Payment>().AddAsync(payment);
            int result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var invoicePayment = new BillPayment
            {
                PaymentId = payment.Id,
                BillId = request.BillId
            };

            await _unitOfWork.GetRepository<BillPayment>().AddAsync(invoicePayment);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var bill = await _unitOfWork.GetRepository<Bill>()
                .FirstOrDefaultAsync(x => x.Id == request.BillId);
            _billService.AddPayment(bill);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            decimal payablesAmount = _billService.GetPayablesAmount(bill.SupplierId);
            await _contactService.UpdateBalance(bill.SupplierId, payablesAmount, cancellationToken);

            return result;
        }
    }
}
