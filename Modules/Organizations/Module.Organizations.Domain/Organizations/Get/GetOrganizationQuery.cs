using Msi.Mediator.Abstractions;
using System;

namespace Module.Organizations.Domain
{
    public class GetOrganizationQuery : IQuery<OrganizationDto>
    {
        public Guid Id { get; set; }
    }
}
