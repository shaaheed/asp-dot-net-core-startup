using Core.Infrastructure.Commands;

namespace Module.Sales.Domain.Products
{
    public class UpdateProductCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsSale { get; set; }
        public bool IsBuy { get; set; }
    }
}
