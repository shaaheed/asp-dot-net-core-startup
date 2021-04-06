using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Core;
using Module.Sales.Domain.Services;

namespace Module.Sales.Domain.InvoicePayments
{
    public class UpdateInvoicePaymentCommandHandler : ICommandHandler<UpdateInvoicePaymentCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public UpdateInvoicePaymentCommandHandler(
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<long> Handle(UpdateInvoicePaymentCommand request, CancellationToken cancellationToken)
        {
            var invoicePaymentRepo = _unitOfWork.GetRepository<InvoicePayment>();
            var payment = invoicePaymentRepo
                .Where(x => x.InvoiceId == request.InvoiceId && x.Id == request.Id && !x.IsDeleted)
                .Select(x => x.Payment)
                .FirstOrDefault();

            if (payment == null)
                throw new NotFoundException("Invoice payment not found");

            request.Map(payment);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            _invoiceService.AddPayment(request.InvoiceId);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
