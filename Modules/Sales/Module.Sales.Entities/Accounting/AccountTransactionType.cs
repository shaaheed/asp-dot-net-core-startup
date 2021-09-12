namespace Module.Sales.Entities
{
    public enum AccountTransactionType : byte
    {
        Bill = 1,
        Invoice,
        SupplierPayment,
        CustomerPayment,
        SpendMoney,
        ReceiveMoney,
        TransferMoney,
        GeneralJournal,
        InventoryAdjustment,
        CreditRefund,
        DebitRefund
    }
}
