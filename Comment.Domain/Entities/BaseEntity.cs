using System;
using Core.Events;
using Core.Interfaces.Entities;

namespace Module.User.Entities
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
