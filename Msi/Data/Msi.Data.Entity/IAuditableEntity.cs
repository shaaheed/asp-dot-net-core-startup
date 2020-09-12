using System;

namespace Msi.Data.Entity
{
    public interface IAuditableEntity<TType>
    {
        TType CreatedBy { get; set; }
        TType UpdatedBy { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
