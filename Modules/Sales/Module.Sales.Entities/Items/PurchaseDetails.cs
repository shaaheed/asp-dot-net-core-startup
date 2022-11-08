using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class PurchaseDetails : OrganizationEntity
    {
        public string Description { get; set; }

        // This field displays the current average cost of the item across all locations. Using the weighted-average method, the average cost is calculated as the total units available during a period divided by the beginning inventory cost plus the cost of additions to inventory.
        // Note: The average cost calculated per location is listed for each location on the Locations subtab.
        // If you use Multiple Units of Measure, average cost is calculated using stock units.

        [Column(TypeName = "decimal(18,4)")]
        public decimal? AverageCost { get; set; }

        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Cost { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal? LastPurchasePrice { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalValue { get; set; }

        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public bool IsPriceTaxInclusive { get; set; }
        public Guid? TaxId { get; set; }
        public virtual TaxCode Tax { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public Guid? SupplierId { get; set; }
        public virtual Contact Supplier { get; set; }

    }
}
