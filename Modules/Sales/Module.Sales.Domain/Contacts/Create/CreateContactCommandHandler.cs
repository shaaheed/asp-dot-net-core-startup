using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using System;
using Module.Systems.Entities;
using Module.Systems.Domain;

namespace Module.Sales.Domain.Contacts
{
    public class CreateContactCommandHandler : ICommandHandler<CreateContactCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateContactCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            // TODO: handle contact person etc
            var repo = _unitOfWork.GetRepository<Contact>();
            
            var entity = request.Map();
            entity.BillingAddressId = await CreateAddress(request.BillingAddress, cancellationToken);
            entity.ShippingAddressId = await CreateAddress(request.ShippingAddress, cancellationToken);
            await repo.AddAsync(entity, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        private async Task<Guid?> CreateAddress(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var address = request.Map();
                await _unitOfWork.GetRepository<Address>().AddAsync(address, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return address?.Id;
            }
            return null;
        }
    }
}
