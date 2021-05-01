using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class GetBillCreateInfoQueryHandler : IQueryHandler<GetBillCreateInfoQuery, BillCreateInfoDto>
    {

        private readonly IBillService _billService;

        public GetBillCreateInfoQueryHandler(
            IBillService billService)
        {
            _billService = billService;
        }

        public Task<BillCreateInfoDto> Handle(GetBillCreateInfoQuery request, CancellationToken cancellationToken)
        {
            var info = new BillCreateInfoDto
            {
                NextBillNumber = _billService.GetNextBillNumber()
            };
            return Task.FromResult(info);
        }
    }
}
