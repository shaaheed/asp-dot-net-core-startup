using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class DeleteVariantOptionCommandHandler : DeleteCommandHandler<VariantOption, DeleteVariantOptionCommand>
    {
        public DeleteVariantOptionCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
