using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Vendors
{
    public class DeleteVendorCommandHandler : ICommandHandler<DeleteVendorCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteVendorCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            //var userRepo = _unitOfWork.GetRepository<User>();
            //var userToBeDeleted = await userRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            //if (userToBeDeleted == null)
            //    throw new NotFoundException("Customer not found");

            //userRepo.Remove(userToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
