using Core.Infrastructure.Commands;
using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Customers
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var userRepo = _unitOfWork.GetRepository<User>();
            User newUser = new User
            {
                FirstName = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                Contact = request.Contact
            };
            var cutomerCreatedEvent = new CustomerCreatedEvent();
            newUser.Append(cutomerCreatedEvent);
            await userRepo.AddAsync(newUser, cancellationToken);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
