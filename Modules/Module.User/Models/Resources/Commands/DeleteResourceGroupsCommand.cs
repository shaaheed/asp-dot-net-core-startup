using Core.Infrastructure.Commands;

namespace Modules.User.Resources.Commands
{
    public class DeleteResourceGroupsCommand : ICommand<object>
    {
        public long[] Ids { get; set; }
    }
}
