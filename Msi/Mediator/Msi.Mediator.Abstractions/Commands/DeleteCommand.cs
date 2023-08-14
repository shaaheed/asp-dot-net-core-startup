using System;

namespace Msi.Mediator.Abstractions
{
    public class DeleteCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
