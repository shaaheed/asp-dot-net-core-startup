using Msi.Mediator.Abstractions;

namespace Module.Payments.Domain
{
    public class DeletePaymentCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
    }
}
