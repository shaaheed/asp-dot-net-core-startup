using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Qoutes
{
    public class GetQouteQuery : IQuery<QouteDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
