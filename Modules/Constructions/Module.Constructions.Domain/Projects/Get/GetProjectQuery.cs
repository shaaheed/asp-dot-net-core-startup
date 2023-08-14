using Msi.Mediator.Abstractions;
using System;

namespace Module.Constructions.Domain
{
    public class GetProjectQuery : IQuery<ProjectDto>
    {
        public Guid Id { get; set; }
    }
}
