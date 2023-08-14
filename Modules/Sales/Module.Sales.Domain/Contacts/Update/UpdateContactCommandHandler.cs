using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Sales.Entities;
using Msi.Core;
using Module.Systems.Entities;
using System;
using Module.Systems.Domain;

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
            // TODO: handle contact person etc
            var entity = await _unitOfWork.GetRepository<Contact>()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException("Contact not found");

            request.Map(entity);

            var billingAddressId = await UpdateAddress(entity.BillingAddressId, request.BillingAddress, cancellationToken);
            if (billingAddressId != null)
            {
                entity.BillingAddressId = billingAddressId;
            }

            var shippingAddressId = await UpdateAddress(entity.ShippingAddressId, request.ShippingAddress, cancellationToken);
            if (shippingAddressId != null)
            {
                entity.BillingAddressId = shippingAddressId;
            }

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task<Guid?> UpdateAddress(Guid? addressId, CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                if (addressId != null)
                {
                    var address = await _unitOfWork.GetRepository<Address>()
                        .FirstOrDefaultAsync(x => x.Id == addressId && !x.IsDeleted, cancellationToken);
                    if (address != null)
                    {
                        request.Map(address);
                    }
                }
                else
                {
                    var address = request.Map();
                    await _unitOfWork.GetRepository<Address>().AddAsync(address, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return address.Id;
                }
            }
            return null;
        }
    }
}
