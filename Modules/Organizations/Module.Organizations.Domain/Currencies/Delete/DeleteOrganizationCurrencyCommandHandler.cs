using Msi.Mediator.Abstractions;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class DeleteOrganizationCurrencyCommandHandler : DeleteCommandHandler<OrganizationCurrency, DeleteOrganizationCurrencyCommand>
    {
        public DeleteOrganizationCurrencyCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
