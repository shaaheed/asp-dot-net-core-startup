using Module.Sales.Entities;

namespace Module.Sales.Domain.Products
{
    public class SaleDetailsRequestDto : ItemDetailsRequestDto
    {
        public decimal? AveragePrice { get; set; }
        public decimal? MRP { get; set; }

        public virtual SaleDetails Map(SaleDetails entity = null)
        {
            entity = base.Map(entity ?? new SaleDetails()) as SaleDetails;
            entity.AveragePrice = AveragePrice;
            entity.MRP = MRP;
            return entity;
        }
    }
}
