using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class ItemSaleDetails : ItemDetails
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal? AveragePrice { get; set; }

        // Maximum retail price (MRP)
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MRP { get; set; }
    }
}
