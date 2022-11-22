using Msi.Mediator.Abstractions;
using System;

namespace Module.Organizations.Domain
{
    public class GetOrganizationCurrencyQuery : IQuery<OrganizationCurrencyDto>
    {
        public Guid Id { get; set; }
    }
}
