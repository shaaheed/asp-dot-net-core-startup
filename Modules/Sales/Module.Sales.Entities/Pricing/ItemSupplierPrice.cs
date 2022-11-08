using Module.Systems.Entities;
using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class ItemSupplierPrice : BaseEntity, IOrganizationEntity
    {
        public string Memo { get; set; }

        public Guid ItemSupplierId { get; set; }
        public virtual ItemSupplier ItemSupplier { get; set; }

        public Guid? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public Guid? OrganizationId { get; set; }

    }
}
