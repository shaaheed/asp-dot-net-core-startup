using Msi.Data.Entity;
using Msi.Mediator.Abstractions;

namespace Msi.Domain.Abstractions
{
    public class NameCrudService : CrudService<NameEntity>
    {
        public NameCrudService(
            ICommandBus commandBus,
            IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }
    }
}
