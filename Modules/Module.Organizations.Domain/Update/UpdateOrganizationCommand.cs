using Core.Infrastructure.Commands;

namespace Module.Organizations.Domain
{
    public class UpdateOrganizationCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
