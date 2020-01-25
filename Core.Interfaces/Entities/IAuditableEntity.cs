using System;

namespace Core.Interfaces.Entities
{
    public interface IAuditableEntity<T> : IEntity
    {
        T CreatedBy { get; set; }
        T UpdatedBy { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
