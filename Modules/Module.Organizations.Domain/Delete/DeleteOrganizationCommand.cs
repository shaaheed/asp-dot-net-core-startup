using Core.Infrastructure.Commands;

namespace Module.Organizations.Domain
{
    public class DeleteOrganizationCommand : ICommand<long>
    {
        public long Id { get; set; }
    }
}
