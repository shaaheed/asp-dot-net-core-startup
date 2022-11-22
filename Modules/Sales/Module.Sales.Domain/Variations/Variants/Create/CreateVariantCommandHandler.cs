using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using System.Linq;

namespace Module.Sales.Domain
{
    public class CreateVariantCommandHandler : ICommandHandler<CreateVariantCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateVariantCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateVariantCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Map();
            var repo = _unitOfWork.GetRepository<Variant>();
            await repo.AddAsync(entity, cancellationToken);
            long result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0 && request.Options.Count > 0)
            {
                var options = request.Options.Select(x => {
                    var option = x.Map();
                    option.VariantId = entity.Id;
                    return option;
                });
                await _unitOfWork.GetRepository<VariantOption>().AddRangeAsync(options);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}
