using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Taxes
{
    public class DeleteTaxCommandHandler : DeleteCommandHandler<TaxCode, DeleteTaxCommand>
    {
        public DeleteTaxCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
