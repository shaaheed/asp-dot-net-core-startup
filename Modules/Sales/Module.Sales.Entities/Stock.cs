using Msi.Data.Entity;
using System;

namespace Module.Sales.Entities
{
    public class Stock : BaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
