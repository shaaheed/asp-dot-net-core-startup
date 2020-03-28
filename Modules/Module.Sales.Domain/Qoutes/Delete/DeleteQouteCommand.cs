using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Qoutes
{
    public class DeleteQouteCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
