//using System;
//using Core.Events;
//using Core.Infrastructure.Attributes;
//using Msi.Data.Entity;

//namespace Core.Interfaces.Entities
//{
//    [IgnoredEntity]
//    public class BaseEntityWithTypeId<TKey> : EventAggregate, IEntity, IAuditableEntity<long>
//    {
//        public TKey Id { get; set; }
//        public long CreatedBy { get; set; }
//        public long UpdatedBy { get; set; }
//        public DateTime? CreatedAt { get; set; }
//        public DateTime? UpdatedAt { get; set; }
//        public long? OrganizationId { get; set; }
//    }
//}
