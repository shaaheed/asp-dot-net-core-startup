using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class DeleteVariantCommandHandler : DeleteCommandHandler<Variant, DeleteVariantOptionCommand>
    {
        public DeleteVariantCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
