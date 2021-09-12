using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using System;

namespace Module.Sales.Domain
{
    public class UpdateBillPaymentCommandHandler : ICommandHandler<UpdateBillPaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillService _billService;
        private readonly IContactService _contactService;

        public UpdateBillPaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IBillService invoiceService,
            IContactService contactService)
        {
            _unitOfWork = unitOfWork;
            _billService = invoiceService;
            _contactService = contactService;
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

            Guid? supplierId = _billService.GetSupplierId(request.BillId);
            decimal payablesAmount = _billService.GetPayablesAmount(supplierId);
            await _contactService.UpdateBalance(supplierId, payablesAmount, cancellationToken);

            return result;
        }
    }
}
