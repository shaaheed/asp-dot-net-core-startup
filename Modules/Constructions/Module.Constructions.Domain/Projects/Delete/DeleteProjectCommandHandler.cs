using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using Module.Constructions.Entities;

namespace Module.Constructions.Domain
{
    public class DeleteProjectCommandHandler : DeleteCommandHandler<Project, DeleteProjectCommand>
    {
        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
