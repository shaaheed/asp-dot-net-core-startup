using Core.Infrastructure.Commands;
using Core.Infrastructure.Exceptions;
using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Customers
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var userToBeDeleted = await userRepo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (userToBeDeleted == null)
                throw new NotFoundException("Customer not found");

            userRepo.Remove(userToBeDeleted);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
