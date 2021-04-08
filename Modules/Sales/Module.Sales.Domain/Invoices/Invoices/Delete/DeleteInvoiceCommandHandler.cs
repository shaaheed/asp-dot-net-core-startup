using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class DeleteInvoiceCommandHandler : ICommandHandler<DeleteInvoiceCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceRepo = _unitOfWork.GetRepository<Invoice>();
            var invoice = await invoiceRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            var invoiceLineItemRepo = _unitOfWork.GetRepository<InvoiceLineItem>();
            var invoiceLineItemsToBeDeleted = invoiceLineItemRepo
                .Where(x => x.InvoiceId == request.Id);
            var lineItemsToBeDeleted = invoiceLineItemsToBeDeleted.Select(x => x.LineItem);

            _unitOfWork.GetRepository<LineItem>().RemoveRange(lineItemsToBeDeleted);
            invoiceLineItemRepo.RemoveRange(invoiceLineItemsToBeDeleted);
            invoiceRepo.Remove(invoice);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
