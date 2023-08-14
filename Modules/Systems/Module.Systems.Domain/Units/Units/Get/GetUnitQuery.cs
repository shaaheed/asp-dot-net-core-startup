using Msi.Mediator.Abstractions;
using System;

namespace Module.Systems.Domain
{
    public class GetUnitQuery : IQuery<UnitDto>
    {
        public Guid Id { get; set; }
    }
}
