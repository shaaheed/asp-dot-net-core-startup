using System;

namespace Module.Organizations.Domain
{
    public class UpdateOrganizationCommand : CreateOrganizationCommand
    {
        public Guid Id { get; set; }
    }
}
