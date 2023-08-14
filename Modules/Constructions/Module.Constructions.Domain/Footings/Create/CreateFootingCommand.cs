using Module.Constructions.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Constructions.Domain
{
    public class CreateFootingCommand : CreateCommand
    {
        public Guid UnitTypeId { get; set; }
        //public FootingType Type { get; set; }
        public string Name { get; set; }
        public float Nos { get; set; }
        public List<FootingValueRequest> Values { get; set; }
        public Guid VolumneUnitId { get; set; }

        public virtual Footing Map(Footing entity = null)
        {
            entity = entity ?? new Footing();
            entity.UnitTypeId = UnitTypeId;
            entity.UnitTypeId = UnitTypeId;
            entity.Name = Name;
            entity.Nos = Nos;
            //entity.VolumneUnitId = VolumneUnitId;
            return entity;
        }
    }
}
