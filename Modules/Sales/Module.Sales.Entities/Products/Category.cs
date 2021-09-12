using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class Category : OrganizationCodeNameEntity
    {
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public string Description { get; set; }
    }
}
