using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Units
{
    public class GetTermQuery : IQuery<TermDto>
    {
        public Guid Id { get; set; }
    }
}
