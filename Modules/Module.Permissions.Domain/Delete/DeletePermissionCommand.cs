using Core.Infrastructure.Commands;

namespace Module.Permissions.Data
{
    public class DeletePermissionCommand : ICommand<long>
    {
        public string Id { get; set; }
    }
}
