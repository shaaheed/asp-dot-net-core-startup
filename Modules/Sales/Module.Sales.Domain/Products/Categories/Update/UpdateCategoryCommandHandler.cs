using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Products
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<Category>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
