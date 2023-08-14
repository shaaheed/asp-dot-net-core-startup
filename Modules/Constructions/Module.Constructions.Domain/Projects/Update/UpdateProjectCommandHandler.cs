using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Constructions.Entities;

namespace Module.Constructions.Domain
{
    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var repo = await _unitOfWork.GetRepository<Project>()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (repo == null)
                throw new NotFoundException("Project not found");

            request.Map(repo);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
