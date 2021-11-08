using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;
using System;

namespace Module.Payments.Domain
{
    public class GetPaymentsQuery : Query<PagedCollection<PaymentDetailsDto>>
    {
        public Guid DocumentId { get; set; }
    }
}
