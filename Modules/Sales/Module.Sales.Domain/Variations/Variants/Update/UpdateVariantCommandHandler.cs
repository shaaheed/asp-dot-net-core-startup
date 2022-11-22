using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Module.Sales.Domain
{
    public class UpdateVariantCommandHandler : ICommandHandler<UpdateVariantCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateVariantCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateVariantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<Variant>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                request.Map(entity);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var variantOptionIds = request.Options.Where(x => x.Id.HasValue).Select(x => x.Id.Value);
            var variantOptionRepo = _unitOfWork.GetRepository<VariantOption>();
            var savedVariantOptions = variantOptionRepo.Where(x => x.VariantId == request.Id).ToList();

            var newVariantOptions = new List<VariantOption>();
            foreach (var requestUnit in request.Options)
            {
                var savedVariantOption = savedVariantOptions.FirstOrDefault(x => x.Id == requestUnit.Id);
                if (savedVariantOption == null)
                {
                    var newVariantOption = requestUnit.Map();
                    newVariantOption.VariantId = request.Id;
                    newVariantOptions.Add(newVariantOption);
                }
                else
                {
                    requestUnit.Map(savedVariantOption);
                    savedVariantOption.VariantId = request.Id;
                }
            }

            if (newVariantOptions.Count > 0)
            {
                await variantOptionRepo.AddRangeAsync(newVariantOptions);
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var toBeRemoved = savedVariantOptions.Where(x => !variantOptionIds.Contains(x.Id));
            if (toBeRemoved?.Count() > 0)
            {
                variantOptionRepo.RemoveRange(toBeRemoved);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}
