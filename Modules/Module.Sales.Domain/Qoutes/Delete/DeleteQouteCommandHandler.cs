using Core.Infrastructure.Commands;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Qoutes
{
    public class DeleteQouteCommandHandler : ICommandHandler<DeleteQouteCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteQouteCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(DeleteQouteCommand request, CancellationToken cancellationToken)
        {
            var qouteRepo = _unitOfWork.GetRepository<Qoute>();
            var qoute = await qouteRepo.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var qouteLineItemRepo = _unitOfWork.GetRepository<QouteLineItem>();
            var qouteLineItemsToBeDeleted = qouteLineItemRepo
                .Where(x => x.QouteId == request.Id);
            var lineItemsToBeDeleted = qouteLineItemsToBeDeleted.Select(x => x.LineItem);

            _unitOfWork.GetRepository<LineItem>().RemoveRange(lineItemsToBeDeleted);
            qouteLineItemRepo.RemoveRange(qouteLineItemsToBeDeleted);
            qouteRepo.Remove(qoute);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
