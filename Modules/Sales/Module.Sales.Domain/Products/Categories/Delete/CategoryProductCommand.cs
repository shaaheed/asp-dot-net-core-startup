using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Products
{
    public class DeleteCategoryCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
