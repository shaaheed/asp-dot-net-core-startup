﻿using Msi.Mediator.Abstractions;
using System;

namespace Module.Permissions.Data
{
    public class CreatePermissionCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
