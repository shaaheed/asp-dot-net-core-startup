using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class UpdateUnitTypeCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual UnitType Map(UnitType entity = null)
        {
            entity = entity ?? new UnitType();
            entity.Name = Name;
            entity.Code = Code;
            return entity;
        }
    }
}
