using Msi.Mediator.Abstractions;

namespace Module.Permissions.Data
{
    public class DeletePermissionCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
