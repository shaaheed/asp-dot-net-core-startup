using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain
{
    public class CreateUnitCommand : ICommand<long>
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public Guid TypeId { get; set; }
        public Guid? BaseUnitId { get; set; }
        public float Factor { get; set; }

        public virtual Unit Map(Unit entity = null)
        {
            entity = entity ?? new Unit();
            entity.Name = Type;
            entity.TypeId = TypeId;
            // TODO entity.BaseUnitId = BaseUnitId;
            entity.ConvertionRate = Factor;
            return entity;
        }
    }
}
