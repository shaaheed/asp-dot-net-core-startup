using Core.Infrastructure.Commands;

namespace Modules.User.Resources.Commands
{
    public class EditResourceGroupsCommand : ICommand<object>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CreateEditResourceGroupCommandModel[] Resources { get; set; }
    }
}
