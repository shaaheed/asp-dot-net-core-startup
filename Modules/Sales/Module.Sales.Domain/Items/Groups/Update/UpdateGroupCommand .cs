using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class UpdateGroupCommand : ICommand<long>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Group Map(Group entity = null)
        {
            entity = entity ?? new Group();
            entity.Name = Name;
            entity.Description = Description;
            return entity;
        }
    }
}
