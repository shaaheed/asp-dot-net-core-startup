namespace Module.Sales.Entities
{
    public enum LineItemType : byte
    {
        Initial = 1,
        Adjustment,
        Sale,
        Purchase,
        Order,
        SaleReturn,
        PurchaseReturn,
        OrderCancel,
        Lost,
        Damage
    }
}
