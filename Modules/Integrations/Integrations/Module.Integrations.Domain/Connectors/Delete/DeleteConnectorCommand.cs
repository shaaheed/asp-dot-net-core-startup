using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class DeleteConnectorCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
