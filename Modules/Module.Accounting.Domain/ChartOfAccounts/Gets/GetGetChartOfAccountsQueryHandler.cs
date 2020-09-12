using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module.Accounting.Entities;
using Module.Accounting.Domain.ChartOfAccounts.Dtos;
using Msi.Data.Abstractions;

namespace Module.Accounting.Domain.ChartOfAccounts
{
    public class GetGetChartOfAccountsQueryHandler : IQueryHandler<GetChartOfAccountsQuery, IEnumerable<ChartOfAccountDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetGetChartOfAccountsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ChartOfAccountDto>> Handle(GetChartOfAccountsQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<ChartOfAccount>()
                .AsQueryable()
                .Select(x => new ChartOfAccountDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
