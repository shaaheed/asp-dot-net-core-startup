using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public enum InventoryEntryType : byte
    {
        Initial = 0,
        Sale = 1,
        Purchase = 2,
    }
}
