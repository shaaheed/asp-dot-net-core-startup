using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Category : OrganizationNameEntity
    {
        public Guid? ParentId { get; set; }
        public Category Parent { get; set; }

        public string Description { get; set; }
    }
}
