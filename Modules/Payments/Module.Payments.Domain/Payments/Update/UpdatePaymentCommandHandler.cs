using Msi.Mediator.Abstractions;
using Core.Infrastructure.Exceptions;
using Module.Payments.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Payments.Domain
{
    public class UpdatePaymentCommandHandler : ICommandHandler<UpdatePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {

            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payment = await paymentRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (payment == null)
                throw new NotFoundException("Payment not found");

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //await invoiceRepo.AddAsync(newInvoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
