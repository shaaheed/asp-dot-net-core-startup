using Msi.Mediator.Abstractions;
using System;

namespace Module.Systems.Domain
{
    public class CreateAddressCommand : CreateAddressRequest, ICreateCommand<Guid?>
    {
        //
    }
}
