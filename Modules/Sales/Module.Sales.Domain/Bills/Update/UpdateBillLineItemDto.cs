namespace Module.Sales.Domain.Bills
{
    public class UpdateBillLineItemDto : BillLineItemBaseDto
    {
        public long? Id { get; set; }
        public long? BillId { get; set; }
        public decimal Price { get; set; }
    }
}
