using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Taxes
{
    public class UpdateTaxCommandHandler : ICommandHandler<UpdateTaxCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaxCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<TaxCode>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
