using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Constructions.Domain
{
    public class GetMaterialQueryHandler : IQueryHandler<GetMaterialQuery, MaterialDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetMaterialQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<MaterialDto> Handle(GetMaterialQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, MaterialDto.Selector(), cancellationToken);
        }
    }
}
