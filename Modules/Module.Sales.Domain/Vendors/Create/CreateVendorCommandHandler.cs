using Core.Infrastructure.Commands;
using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Core.Infrastructure.Exceptions;

namespace Module.Sales.Domain.Vendors
{
    public class CreateVendorCommandHandler : ICommandHandler<CreateVendorCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateVendorCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {

            var vendorRole = await _unitOfWork.GetRepository<Role>()
                .FirstOrDefaultAsync(x => x.Code == "vendor");

            if (vendorRole == null)
                throw new ValidationException($"Invalid role");

            var userRepo = _unitOfWork.GetRepository<User>();
            User newUser = new User
            {
                FirstName = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                Contact = request.Contact
            };

            var vendorCreatedEvent = new VendorCreatedEvent();
            newUser.Append(vendorCreatedEvent);
            await userRepo.AddAsync(newUser, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newUserRole = new UserRole
            {
                UserId = newUser.Id,
                RoleId = vendorRole.Id
            };

            await _unitOfWork.GetRepository<UserRole>().AddAsync(newUserRole, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
