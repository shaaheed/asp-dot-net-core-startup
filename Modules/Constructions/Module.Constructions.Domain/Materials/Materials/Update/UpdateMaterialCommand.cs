using System;

namespace Module.Constructions.Domain
{
    public class UpdateMaterialCommand : CreateMaterialCommand
    {
        public Guid Id { get; set; }
    }
}
