using System;

namespace Module.Constructions.Entities
{
    public class FootingValueRequest
    {
        public Guid? Id { get; set; }
        //public FootingValueType Type { get; set; }
        public float MultiplyBy { get; set; }
        public float Value { get; set; }
        public Guid UnitId { get; set; }
    }
}
