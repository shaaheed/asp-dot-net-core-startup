using Module.Systems.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(Project), Schema = SchemaConstants.Constructions)]
    public class Project : OrganizationNameEntity
    {
        public Guid? ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string Description { get; set; }

        public Guid? UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }

        public float PlotArea { get; set; }
       
        // Plot Area Unit
        public Guid? UnitId { get; set; }
        public Unit Unit { get; set; }


        // Project Address
        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
