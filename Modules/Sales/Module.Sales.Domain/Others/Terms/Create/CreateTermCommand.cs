﻿using Module.Sales.Entities;
using Msi.Mediator.Abstractions;

namespace Module.Sales.Domain.Units
{
    public class CreateTermCommand : ICommand<long>
    {
        public string Name { get; set; }
        public float Days { get; set; }
        public bool IsActive { get; set; }

        public virtual Term Map(Term entity = null)
        {
            entity = entity ?? new Term();
            entity.Name = Name;
            entity.Days = Days;
            entity.IsActive = IsActive;
            return entity;
        }
    }
}
