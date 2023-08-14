using System;

namespace Module.Systems.Domain
{
    public class UpdateAddressCommand : CreateAddressCommand
    {
        public Guid Id { get; set; }
    }
}
