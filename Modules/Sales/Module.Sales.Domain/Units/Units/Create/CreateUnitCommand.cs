using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class CreateUnitCommand : ICommand<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public Guid TypeId { get; set; }
        public Guid? BaseUnitId { get; set; }
        public float Factor { get; set; }

        public virtual Unit Map(Unit entity = null)
        {
            entity = entity ?? new Unit();
            entity.Name = Name;
            entity.Code = Code;
            entity.Description = Description;
            entity.Symbol = Symbol;
            entity.TypeId = TypeId;
            entity.BaseUnitId = BaseUnitId;
            entity.Factor = Factor;
            return entity;
        }
    }
}
