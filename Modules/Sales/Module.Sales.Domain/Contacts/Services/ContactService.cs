using Module.Sales.Entities;
using Msi.Data.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Contact> _contactRepo;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _contactRepo = _unitOfWork.GetRepository<Contact>();
        }

        public async Task UpdateBalance(Guid? contactId, decimal amount, CancellationToken cancellationToken = default)
        {
            if (contactId != null)
            {
                var contact = await _contactRepo.FirstOrDefaultAsync(x => x.Id == contactId.Value && !x.IsDeleted);
                if (contact != null)
                {
                    contact.Balance = amount;
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
