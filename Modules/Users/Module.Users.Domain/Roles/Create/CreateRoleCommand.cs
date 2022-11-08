using Msi.Mediator.Abstractions;

namespace Module.Accounts.Domain
{
    public class CreateRoleCommand : ICommand<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }

}
