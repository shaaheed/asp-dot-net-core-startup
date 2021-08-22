using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class GetInvoicesMetaQueryHandler : IQueryHandler<GetInvoicesMetaQuery, InvoicesMetaDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicesMetaQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<InvoicesMetaDto> Handle(GetInvoicesMetaQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
