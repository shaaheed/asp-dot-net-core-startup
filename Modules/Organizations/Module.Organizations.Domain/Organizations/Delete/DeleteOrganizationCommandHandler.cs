using Msi.Mediator.Abstractions;
using Module.Organizations.Entities;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class DeleteOrganizationCommandHandler : DeleteCommandHandler<Organization, DeleteOrganizationCommand>
    {
        public DeleteOrganizationCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
