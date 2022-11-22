// Copyright (c) Sahidul Islam. All Rights Reserved.
// Author: https://github.com/shaaheed

using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class BaseEntity : RootEntity, IAuditableEntity<Guid>
    {
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
