using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;
using System;

namespace Module.Organizations.Domain
{
    public class GetOrganizationCurrenciesQuery : Query<PagedCollection<OrganizationCurrencyDto>>
    {
        public Guid OrganizationId { get; set; }
    }
}
