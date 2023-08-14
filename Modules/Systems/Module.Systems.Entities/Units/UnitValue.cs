using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    public class UnitValue : RootOrganizationEntity
    {
        public float Value { get; set; }
        public Guid UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
