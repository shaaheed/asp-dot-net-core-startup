using Core.Infrastructure.Commands;
using Module.Payments.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Payments.Domain
{
    public class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreatePaymentCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var paymentRepo = _unitOfWork.GetRepository<Payment>();
            var newPayment = new Payment
            {
                
            };
            //await paymentRepo.AddAsync(newInvoice, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
