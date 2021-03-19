using System;

namespace Module.Systems.Domain
{
    public class IdNameDto<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }

    }
}
