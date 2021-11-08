using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class GetConnectionQuery : IQuery<ConnectionDto>
    {
        public Guid Id { get; set; }
    }
}
