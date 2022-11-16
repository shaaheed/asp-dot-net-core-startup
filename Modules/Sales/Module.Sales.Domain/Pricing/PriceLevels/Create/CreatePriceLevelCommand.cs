using Module.Sales.Entities;
using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain
{
    public class CreatePriceLevelCommand : ICommand<long>
    {
        public string Name { get; set; }

        public virtual PriceLevel Map(PriceLevel entity = null)
        {
            entity = entity ?? new PriceLevel();
            entity.Name = Name;
            return entity;
        }
    }
}
