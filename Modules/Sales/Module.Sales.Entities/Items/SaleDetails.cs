using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class SaleDetails : ItemDetails
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal? AveragePrice { get; set; }

        
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }


        // Maximum retail price (MRP)
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MRP { get; set; }
    }
}
