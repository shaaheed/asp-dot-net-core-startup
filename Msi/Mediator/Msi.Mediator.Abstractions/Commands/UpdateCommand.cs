using System;

namespace Msi.Mediator.Abstractions
{
    public class UpdateCommand : ICreateCommand<Guid?>, IUpdateCommand<Guid?>
    {
    }
}
