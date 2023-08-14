using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Constructions.Domain
{
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProjectQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, ProjectDto.Selector(), cancellationToken);
        }
    }
}
