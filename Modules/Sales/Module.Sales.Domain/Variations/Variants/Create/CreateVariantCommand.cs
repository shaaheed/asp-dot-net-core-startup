using Module.Sales.Domain.Units;
using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateVariantCommand : ICommand<long>
    {
        public string Name { get; set; }

        public List<VariantOptionRequestDto> Options { get; set; }

        public virtual Variant Map(Variant entity = null)
        {
            entity = entity ?? new Variant();
            entity.Name = Name;
            return entity;
        }
    }
}
