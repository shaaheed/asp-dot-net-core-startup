using Module.Sales.Entities;
using Msi.Data.Abstractions;
using System.Linq;

namespace Module.Sales.Domain
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bill> _billRepo;

        public BillService(
            IUnitOfWork unitOfWork,
            IDocumentService documentService)
        {
            _unitOfWork = unitOfWork;
            _billRepo = _unitOfWork.GetRepository<Bill>();
        }

        public string GetNextBillNumber()
        {
            var count = _billRepo
                .WhereAsReadOnly(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"BILL-{count + 1}";
        }     
    }
}
