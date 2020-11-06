﻿using Msi.Data.Entity;
using System;

namespace Module.Users.Entities
{
    public class UserRole : BaseEntity<long>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}