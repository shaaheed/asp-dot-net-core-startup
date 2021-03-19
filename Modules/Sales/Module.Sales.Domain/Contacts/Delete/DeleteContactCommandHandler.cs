using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using Msi.Core;

namespace Module.Sales.Domain.Contacts
{
    public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Contact>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Contact not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
