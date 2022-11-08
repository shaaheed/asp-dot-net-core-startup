using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class SaleDetails : OrganizationEntity
    {
        public string Description { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal? AveragePrice { get; set; }

        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }


        // Maximum retail price (MRP)
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MRP { get; set; }

        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public bool IsPriceTaxInclusive { get; set; }
        public Guid? TaxId { get; set; }
        public virtual TaxCode Tax { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
