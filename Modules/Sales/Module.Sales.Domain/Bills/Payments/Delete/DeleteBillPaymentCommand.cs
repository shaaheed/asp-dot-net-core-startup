using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class DeleteBillPaymentCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
    }
}
