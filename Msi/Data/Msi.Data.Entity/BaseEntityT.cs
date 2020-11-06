using System;

namespace Msi.Data.Entity
{
    [IgnoredEntity]
    public class BaseEntity<T> : IGenericEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
