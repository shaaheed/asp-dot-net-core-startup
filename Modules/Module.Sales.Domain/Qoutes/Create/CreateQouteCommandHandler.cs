using Core.Infrastructure.Commands;
using Module.Sales.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Qoutes
{
    public class CreateQouteCommandHandler : ICommandHandler<CreateQouteCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateQouteCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateQouteCommand request, CancellationToken cancellationToken)
        {

            var qouteRepo = _unitOfWork.GetRepository<Qoute>();
            var newQoute = new Qoute
            {
                Memo = request.Memo,
                ExpiresOn = request.ExpiresOn,
                IssueDate = DateTimeOffset.UtcNow,
                CustomerId = request.CustomerId
            };

            var lineItemRepo = _unitOfWork.GetRepository<LineItem>();
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

            var qouteLineItemsRepo = _unitOfWork.GetRepository<QouteLineItem>();
            var newQouteLineItems = newLineItems.Select(x => new QouteLineItem
            {
                Qoute = newQoute,
                LineItem = x
            });

            newQoute.QouteLineItems = newQouteLineItems.ToList();
            newQoute.Calculate();

            await qouteRepo.AddAsync(newQoute, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
