using Core.Infrastructure.Commands;
using Module.Payments.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Payments.Domain
{
    public class DeletePaymentCommandHandler : ICommandHandler<DeletePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeletePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var payment = await paymentRepo.FirstOrDefaultAsync(x => x.Id == request.Id);
            paymentRepo.Remove(payment);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
