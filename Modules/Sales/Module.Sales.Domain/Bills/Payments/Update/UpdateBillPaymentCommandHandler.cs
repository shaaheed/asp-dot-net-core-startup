using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;

namespace Module.Sales.Domain
{
    public class UpdateBillPaymentCommandHandler : ICommandHandler<UpdateBillPaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;

        public UpdateBillPaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _billService = invoiceService;
        }

        public async Task<long> Handle(UpdateBillPaymentCommand request, CancellationToken cancellationToken)
        {
            var invoicePaymentRepo = _unitOfWork.GetRepository<BillPayment>();
            var payment = invoicePaymentRepo
                .Where(x => x.BillId == request.BillId && x.Id == request.Id)
                .Select(x => x.Payment)
                .FirstOrDefault();

            if (payment == null)
                throw new NotFoundException("Bill payment not found");

            request.Map(payment);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _billService.AddPayment(request.BillId);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
