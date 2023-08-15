using Msi.Mediator.Abstractions;
using Msi.Data.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Items
{
    public class UpdateGroupCommandHandler : ICommandHandler<UpdateGroupCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateGroupCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<Group>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
