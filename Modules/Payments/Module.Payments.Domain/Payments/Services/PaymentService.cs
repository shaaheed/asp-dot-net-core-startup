using Module.Payments.Entities;
using Msi.Data.Abstractions;
using Msi.Domain.Abstractions;
using Msi.Mediator.Abstractions;
using System;
using System.Linq;
using System.Threading;

namespace Module.Payments.Domain
{
    public class PaymentService : CrudService<Payment>, IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(
            IUnitOfWork unitOfWork,
            ICommandBus commandBus,
            IQueryBus queryBus) : base(commandBus, queryBus)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal GetPaymentsAmount(Guid documentId, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GetRepository<Payment>()
                .WhereAsReadOnly(x => x.DocumentId == documentId && !x.IsDeleted)
                .Select(x => x.Amount)
                .Sum();
        }

        public decimal GetPaymentsAmount(Guid documentId, Guid customerId, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.GetRepository<Payment>()
                .WhereAsReadOnly(x => x.DocumentId == documentId && x.CustomerId == customerId && !x.IsDeleted)
                .Select(x => x.Amount)
                .Sum();
        }
    }
}
