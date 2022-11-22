using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class CreateVariantOptionCommand : ICommand<long>
    {
        public string Name { get; set; }
        public Guid VariantId { get; set; }

        public virtual VariantOption Map(VariantOption entity = null)
        {
            entity = entity ?? new VariantOption();
            entity.Name = Name;
            entity.VariantId = VariantId;
            return entity;
        }
    }
}
