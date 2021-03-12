using System;

namespace Module.Users.Domain
{
    public class UpdateRoleCommand : CreateRoleCommand
    {
        public Guid Id { get; set; }

    }

}
