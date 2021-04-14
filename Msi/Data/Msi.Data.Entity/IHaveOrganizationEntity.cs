using System;

namespace Msi.Data.Entity
{
    public interface IHaveOrganizationEntity
    {
        Guid? OrganizationId { get; set; }
    }
}
