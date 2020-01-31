using Core.Infrastructure.Commands;

namespace Modules.User.Resources.Commands
{
    public class CreateResourceGroupCommand : ICommand<object>
    {
        public string Name { get; set; }
        public CreateEditResourceGroupCommandModel[] Resources { get; set; }
    }
}
