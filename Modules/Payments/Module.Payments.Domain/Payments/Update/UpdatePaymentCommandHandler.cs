using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using Msi.Core;
using System;

namespace Module.Payments.Domain
{
    public class UpdatePaymentCommandHandler : ICommandHandler<UpdatePaymentCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {

            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payment = await paymentRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (payment == null)
                throw new NotFoundException("Payment not found");

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
