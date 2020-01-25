﻿using System;
using Core.Events;

namespace Core.Interfaces.Entities
{
    public class BaseEntity : EventAggregate, IEntity, IAuditableEntity<long>
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
