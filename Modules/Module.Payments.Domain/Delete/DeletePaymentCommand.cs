using Core.Infrastructure.Commands;

namespace Module.Payments.Domain
{
    public class DeletePaymentCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
