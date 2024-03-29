﻿using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    [IgnoredEntity]
    public class OrganizationCodeNameEntity : NameEntity, IOrganizationEntity
    {
        public string Code { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
