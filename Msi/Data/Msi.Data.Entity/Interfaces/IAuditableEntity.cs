using System;

namespace Msi.Data.Entity
{
    public interface IAuditableEntity<TType>
    {
        TType CreatedBy { get; set; }
        TType UpdatedBy { get; set; }
        DateTimeOffset? CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
    }
}
