namespace Module.Sales.Entities
{
    public class InventoryEntry : InventoryBase
    {
        public InventoryEntryType Type { get; set; }
        public string Note { get; set; }

        public Guid? InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public float Quantity { get; set; }

    }
}
