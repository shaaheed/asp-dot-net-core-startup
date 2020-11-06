namespace Module.Sales.Domain.Bills
{
    public class CreateBillLineItemDto : BillLineItemBaseDto
    {
        public long? BillId { get; set; }
        public decimal Price { get; set; }
    }
}
