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
    public class DeleteBillPaymentCommandHandler : ICommandHandler<DeleteBillPaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;

        public DeleteBillPaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService billService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _billService = billService;
            _contactService = contactService;
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

            Guid? supplierId = _billService.GetSupplierId(request.BillId);
            decimal payablesAmount = _billService.GetPayablesAmount(supplierId);
            await _contactService.UpdateBalance(supplierId, payablesAmount, cancellationToken);

            return result;
        }
    }
}
