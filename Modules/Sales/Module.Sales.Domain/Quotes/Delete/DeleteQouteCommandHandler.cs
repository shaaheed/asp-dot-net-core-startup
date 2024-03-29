﻿using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Qoutes
{
    public class DeleteQouteCommandHandler : ICommandHandler<DeleteQouteCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteQouteCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteQouteCommand request, CancellationToken cancellationToken)
        {
            var qouteRepo = _unitOfWork.GetRepository<Quote>();
            var qoute = await qouteRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            var qouteLineItemRepo = _unitOfWork.GetRepository<QuoteLineItem>();
            var qouteLineItemsToBeDeleted = qouteLineItemRepo
                .Where(x => x.QuoteId == request.Id);
            var lineItemsToBeDeleted = qouteLineItemsToBeDeleted.Select(x => x.LineItem);

            _unitOfWork.GetRepository<LineItem>().RemoveRange(lineItemsToBeDeleted);
            qouteLineItemRepo.RemoveRange(qouteLineItemsToBeDeleted);
            qouteRepo.Remove(qoute);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
