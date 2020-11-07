using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class BaseEntity<T> : IGenericEntity<T>, IAuditableEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public T CreatedBy { get; set; }
        public T UpdatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
