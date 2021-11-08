using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Payments.Entities;

namespace Module.Payments.Domain
{
    public class DeletePaymentCommandHandler : ICommandHandler<DeletePaymentCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeletePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payment = await paymentRepo.FirstOrDefaultAsync(x => x.Id == request.Id && x.DocumentId == request.DocumentId && !x.IsDeleted);
            paymentRepo.Remove(payment);

            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
