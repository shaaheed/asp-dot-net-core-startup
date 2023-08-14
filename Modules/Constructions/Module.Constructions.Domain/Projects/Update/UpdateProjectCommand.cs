using System;

namespace Module.Constructions.Domain
{
    public class UpdateProjectCommand : CreateProjectCommand
    {
        public Guid Id { get; set; }
    }
}
