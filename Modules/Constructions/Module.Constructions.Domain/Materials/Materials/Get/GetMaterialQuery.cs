using Msi.Mediator.Abstractions;
using System;

namespace Module.Constructions.Domain
{
    public class GetMaterialQuery : IQuery<MaterialDto>
    {
        public Guid Id { get; set; }
    }
}
