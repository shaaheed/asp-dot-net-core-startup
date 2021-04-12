using Msi.Data.Entity;
using System;

namespace Module.Systems.Entities
{
    public class KeyValue : IEntity
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
