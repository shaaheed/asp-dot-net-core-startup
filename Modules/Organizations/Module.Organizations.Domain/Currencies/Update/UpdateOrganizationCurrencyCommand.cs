using System;

namespace Module.Organizations.Domain
{
    public class UpdateOrganizationCurrencyCommand : CreateOrganizationCurrencyCommand
    {
        public Guid Id { get; set; }
    }
}
