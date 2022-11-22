using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Contacts
{
    public class DeleteContactCommandHandler : DeleteCommandHandler<Contact, DeleteContactCommand>
    {
        public DeleteContactCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
