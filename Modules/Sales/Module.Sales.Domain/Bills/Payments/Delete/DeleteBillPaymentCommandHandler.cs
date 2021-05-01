using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;

namespace Module.Sales.Domain
{
    public class DeleteBillPaymentCommandHandler : ICommandHandler<DeleteBillPaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;

        public DeleteBillPaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService billService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
        }

        public async Task<long> Handle(DeleteBillPaymentCommand request, CancellationToken cancellationToken)
        {
            var billPaymentRepo = _unitOfWork.GetRepository<BillPayment>();
            var billPayments = billPaymentRepo
                .Where(x => x.BillId == request.BillId && x.Id == request.Id);

            var paymentIds = billPayments.Select(x => x.PaymentId).ToList();
            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payments = paymentRepo.Where(x => paymentIds.Contains(x.Id));
           
            paymentRepo.RemoveRange(payments);
            billPaymentRepo.RemoveRange(billPayments);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _billService.AddPayment(request.BillId);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
