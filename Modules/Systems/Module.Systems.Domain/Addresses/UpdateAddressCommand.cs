using System;

namespace Module.Systems.Domain.Addresses
{
    public class UpdateAddressCommand : CreateAddressCommand
    {
        public Guid Id { get; set; }
    }
}
