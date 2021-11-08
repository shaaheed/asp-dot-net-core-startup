using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class UpdateProviderCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
