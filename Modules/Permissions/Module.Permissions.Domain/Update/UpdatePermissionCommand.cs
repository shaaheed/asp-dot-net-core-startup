using Msi.Mediator.Abstractions;

namespace Module.Permissions.Domain
{
    public class UpdatePermissionCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
