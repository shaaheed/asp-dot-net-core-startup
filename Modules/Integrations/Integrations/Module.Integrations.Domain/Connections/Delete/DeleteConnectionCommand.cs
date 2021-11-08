using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class DeleteConnectionCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
