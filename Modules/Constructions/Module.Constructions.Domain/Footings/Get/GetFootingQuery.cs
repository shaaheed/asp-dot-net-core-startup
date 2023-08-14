using Msi.Mediator.Abstractions;
using System;

namespace Module.Constructions.Domain
{
    public class GetFootingQuery : IQuery<FootingDto>
    {
        public Guid Id { get; set; }
    }
}
