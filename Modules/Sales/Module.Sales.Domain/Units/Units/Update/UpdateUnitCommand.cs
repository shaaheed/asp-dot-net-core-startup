using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class UpdateUnitCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public Guid TypeId { get; set; }

        public virtual Unit Map(Unit entity = null)
        {
            entity = entity ?? new Unit();
            entity.Name = Name;
            entity.Code = Code;
            entity.Description = Description;
            entity.Symbol = Symbol;
            entity.TypeId = TypeId;
            return entity;
        }
    }
}
