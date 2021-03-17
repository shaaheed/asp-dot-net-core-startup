namespace Module.Sales.Domain.Qoutes
{
    public class UpdateQouteLineItemDto : QouteLineItemBaseDto
    {
        public long? Id { get; set; }
        public long? QouteId { get; set; }
        public decimal Price { get; set; }
    }
}
