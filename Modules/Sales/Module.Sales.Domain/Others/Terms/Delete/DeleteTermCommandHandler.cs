using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class DeleteTermCommandHandler : DeleteCommandHandler<Term, DeleteTermCommand>
    {
        public DeleteTermCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
