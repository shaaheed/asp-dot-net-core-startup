using Core.Infrastructure.Commands;
using Module.Users.Entities;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Customers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.GetRepository<User>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if(customer != null)
            {
                customer.FirstName = request.Name;
                customer.Email = request.Email;
                customer.Mobile = request.Mobile;
                customer.Contact = request.Contact;
                var newEvent = new CustomerUpdatedEvent();
                newEvent.GenerateType();
                customer.Append(newEvent);
            }            
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
