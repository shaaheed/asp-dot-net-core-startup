using Msi.Mediator.Abstractions;

namespace Module.Organizations.Domain
{
    public class CreateOrganizationCommand : ICommand<long>
    {
        public string Name { get; set; }
    }
}
