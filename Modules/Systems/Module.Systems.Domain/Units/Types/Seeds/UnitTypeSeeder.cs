using Module.Systems.Entities;
using Msi.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Systems.Domain
{
    public class UnitTypeSeeder : AbstractSeeder<UnitType>
    {
        public override IEnumerable<UnitType> GetSeeds()
        {
            return new List<UnitType>
            {
                new UnitType {
                    Id = new Guid("6a94f05d-2646-4784-952d-230b7f1850ac"),
                    Name = "Length",
                },
            };
        }
    }
}
