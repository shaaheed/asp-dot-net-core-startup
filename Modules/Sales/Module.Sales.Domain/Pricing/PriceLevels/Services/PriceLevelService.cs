using Module.Payments.Entities;
using Msi.Domain.Abstractions;
using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain
{
    public class PriceLevelService : CrudService<Payment>, IPriceLevelService
    {
        public PriceLevelService(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }
    }
}
