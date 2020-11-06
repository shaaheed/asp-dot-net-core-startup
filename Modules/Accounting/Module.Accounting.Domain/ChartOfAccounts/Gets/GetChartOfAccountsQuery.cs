using Msi.Mediator.Abstractions;
using Module.Accounting.Domain.ChartOfAccounts.Dtos;
using System.Collections.Generic;

namespace Module.Accounting.Domain.ChartOfAccounts
{
    public class GetChartOfAccountsQuery : IQuery<IEnumerable<ChartOfAccountDto>>
    {
    }
}
