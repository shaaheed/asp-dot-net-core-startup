using Module.Systems.Domain;
using System;

namespace Module.Constructions.Entities
{
    public class FootingValueDto
    {
        public Guid Id { get; set; }
        //public FootingValueType Type { get; set; }
        public float Value { get; set; }
        public GuidIdNameDto Unit { get; set; }
    }
}
