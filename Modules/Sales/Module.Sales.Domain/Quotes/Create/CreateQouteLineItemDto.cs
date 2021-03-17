namespace Module.Sales.Domain.Qoutes
{
    public class CreateQouteLineItemDto : QouteLineItemBaseDto
    {
        public long? QouteId { get; set; }
        public decimal Price { get; set; }
    }
}
