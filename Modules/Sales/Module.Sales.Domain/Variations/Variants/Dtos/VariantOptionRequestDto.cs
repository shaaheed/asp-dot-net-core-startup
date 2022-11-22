using Module.Sales.Entities;
using System;

namespace Module.Sales.Domain
{
    public class VariantOptionRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid VariantId { get; set; }

        public virtual VariantOption Map(VariantOption entity = null)
        {
            entity = entity ?? new VariantOption();
            entity.Name = Name;
            return entity;
        }
    }
}
