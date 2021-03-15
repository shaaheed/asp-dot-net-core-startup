using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class UpdateCategoryCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Category Map(Category entity = null)
        {
            entity = entity ?? new Category();
            entity.Name = Name;
            entity.Code = Code;
            entity.Description = Description;
            return entity;
        }
    }
}
