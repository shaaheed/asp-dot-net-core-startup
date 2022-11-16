using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Payments.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Payments.Domain
{
    public class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreatePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = request.Map();
            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            await paymentRepo.AddAsync(payment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return payment.Id;
        }
    }
}
