using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Constructions.Entities;

namespace Module.Constructions.Domain
{
    public class DeleteFootingCommandHandler : DeleteCommandHandler<Footing, DeleteFootingCommand>
    {
        public DeleteFootingCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
