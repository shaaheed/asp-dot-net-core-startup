using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;

namespace Module.Sales.Domain.Contacts
{
    public class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            // TODO: handle billing, shipping address, contact person etc
            var entity = await _unitOfWork.GetRepository<Contact>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                request.Map(entity);
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
