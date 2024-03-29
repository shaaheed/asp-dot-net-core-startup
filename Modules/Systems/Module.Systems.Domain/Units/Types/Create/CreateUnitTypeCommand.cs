﻿using Module.Systems.Entities;
using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Systems.Domain
{
    public class CreateUnitTypeCommand : ICommand<long>
    {
        public string Name { get; set; }

        public List<UnitRequestDto> Units { get; set; }

        public virtual UnitType Map(UnitType entity = null)
        {
            entity = entity ?? new UnitType();
            entity.Name = Name;
            return entity;
        }
    }
}
