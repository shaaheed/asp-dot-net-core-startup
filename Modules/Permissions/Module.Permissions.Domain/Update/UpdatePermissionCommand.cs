using Msi.Mediator.Abstractions;
using System;

namespace Module.Permissions.Domain
{
    public class UpdatePermissionCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
