using Core.Infrastructure.Commands;
using Core.Infrastructure.Exceptions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Qoutes
{
    public class UpdateQouteCommandHandler : ICommandHandler<UpdateQouteCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateQouteCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(UpdateQouteCommand request, CancellationToken cancellationToken)
        {

            var qouteRepo = _unitOfWork.GetRepository<Qoute>();
            var qoute = await qouteRepo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (qoute == null)
                throw new NotFoundException("Qoute not found");

            qoute.CustomerId = request.CustomerId;

            var qouteLineItemsRepo = _unitOfWork.GetRepository<QouteLineItem>();
            var qouteLineItemsToBeRemoved = qouteLineItemsRepo.Where(x => x.QouteId == request.Id);
            var lineItemsToBeRemoved = qouteLineItemsToBeRemoved.Select(x => x.LineItem);

            qouteLineItemsRepo.RemoveRange(qouteLineItemsToBeRemoved);
            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
            lineItemRepo.RemoveRange(lineItemsToBeRemoved);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newLineItems = request.Items.Select(x => new LineItem
            {
                Name = x.Name,
                Description = x.Description,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                Total = x.Quantity * x.UnitPrice,
                UnitPrice = x.UnitPrice,
                Note = x.Note
            });

            var newQouteLineItems = newLineItems.Select(x => new QouteLineItem
            {
                Qoute = qoute,
                LineItem = x
            });

            qoute.QouteLineItems = newQouteLineItems.ToList();
            qoute.Calculate();

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
