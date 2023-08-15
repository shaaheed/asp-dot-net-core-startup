using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class GetItemQuery : IQuery<ItemDto>
    {
        public Guid Id { get; set; }
    }
}
