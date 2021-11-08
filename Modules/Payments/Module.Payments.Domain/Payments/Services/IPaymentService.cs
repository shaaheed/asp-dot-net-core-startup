using Module.Payments.Entities;
using Msi.Domain.Abstractions;
using Msi.Service.Abstractions;
using System;
using System.Threading;

namespace Module.Payments.Domain
{
    public interface IPaymentService : ICrudService<Payment>, IScopedService
    {
        decimal GetPaymentsAmount(Guid documentId, CancellationToken cancellationToken = default);

        decimal GetPaymentsAmount(Guid documentId, Guid customerId, CancellationToken cancellationToken = default);
    }
}
