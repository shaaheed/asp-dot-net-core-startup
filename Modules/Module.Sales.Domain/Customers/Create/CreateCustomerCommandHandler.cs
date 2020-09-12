using Core.Infrastructure.Commands;
using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Core.Infrastructure.Exceptions;

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

            var customerRole = await _unitOfWork.GetRepository<Role>()
                .FirstOrDefaultAsync(x => x.Code == "customer");

            if (customerRole == null)
                throw new ValidationException($"Invalid role");

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
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newUserRole = new UserRole
            {
                UserId = newUser.Id,
                RoleId = customerRole.Id
            };

            await _unitOfWork.GetRepository<UserRole>().AddAsync(newUserRole, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
