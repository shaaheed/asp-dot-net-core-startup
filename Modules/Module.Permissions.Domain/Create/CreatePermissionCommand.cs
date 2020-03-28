using Core.Infrastructure.Commands;

namespace Module.Permissions.Data
{
    public class CreatePermissionCommand : ICommand<long>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
