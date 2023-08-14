using Module.Constructions.Entities;
using Module.Systems.Domain;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Constructions.Domain
{
    public class CreateProjectCommand : ICommand<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ClientId { get; set; }

        public Guid? UnitTypeId { get; set; }

        public float PlotArea { get; set; }

        // Plot Area Unit
        public Guid? UnitId { get; set; }

        public CreateAddressCommand Address { get; set; }

        public virtual Project Map(Project entity = null)
        {
            entity = entity ?? new Project();
            entity.Name = Name;
            entity.Description = Description;
            entity.UnitTypeId = UnitTypeId;
            entity.UnitId = UnitId;
            return entity;
        }
    }
}
