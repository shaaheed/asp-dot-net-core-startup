using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class BaseEntity<T> : RootEntity<T>, IAuditableEntity<T>
    {
        public bool IsDeleted { get; set; }
        public T CreatedBy { get; set; }
        public T UpdatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
