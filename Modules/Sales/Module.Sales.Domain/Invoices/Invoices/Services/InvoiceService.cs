using Module.Sales.Entities;
using Msi.Data.Abstractions;
using System.Linq;

namespace Module.Sales.Domain
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Invoice> _invoiceRepo;

        public InvoiceService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _invoiceRepo = _unitOfWork.GetRepository<Invoice>();
        }

        public string GetNextInvoiceNumber()
        {
            var count = _invoiceRepo
                .WhereAsReadOnly(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"INV-{count + 1}";
        }
    }
}
