using System;

namespace Module.Accounts.Domain
{
    public class UpdateRoleCommand : CreateRoleCommand
    {
        public Guid Id { get; set; }

    }

}
