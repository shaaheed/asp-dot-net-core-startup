using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.ChartOfAccounts
{
    public class GetChartOfAccountsQuery : IQuery<IEnumerable<ChartOfAccountDto>>
    {
    }
}
