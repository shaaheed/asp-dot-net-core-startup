using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Items
{
    public class GetGroupQuery : IQuery<GroupDto>
    {
        public Guid Id { get; set; }
    }
}
