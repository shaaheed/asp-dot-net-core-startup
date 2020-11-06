using System;

namespace Module.Core.Domain
{
    public class IdNameDto<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }

    }
}
