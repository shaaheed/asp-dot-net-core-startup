using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    // Unit of Measurement
    public class Unit : BaseEntity, IOrganizationEntity
    {
        public string Name { get; set; }
        public string PluralName { get; set; }

        public string Abbreviation { get; set; }
        public string PluralAbbreviation { get; set; }

        public string Description { get; set; }

        public Guid TypeId { get; set; }
        public UnitType Type { get; set; }

        public bool IsBaseUnit { get; set; }

        // Convertion Rate (Base)
        public float ConvertionRate { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}
