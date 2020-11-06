using Msi.Mediator.Abstractions;
using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Vendors
{
    public class UpdateVendorCommandHandler : ICommandHandler<UpdateVendorCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateVendorCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.GetRepository<User>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(customer != null)
            {
                customer.FirstName = request.Name;
                customer.Email = request.Email;
                customer.Mobile = request.Mobile;
                customer.Contact = request.Contact;
                var newEvent = new VendorUpdatedEvent();
                newEvent.GenerateType();
                // customer.Append(newEvent);
            }            
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
