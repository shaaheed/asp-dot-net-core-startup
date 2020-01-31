using Core.Infrastructure.Commands;
using System.Collections.Generic;

namespace Modules.User.Resources.Commands
{
    public class SeedPermissionsCommand : ICommand<object>
    {
        public Dictionary<string, List<string>> Resources { get; set; }
    }
}
