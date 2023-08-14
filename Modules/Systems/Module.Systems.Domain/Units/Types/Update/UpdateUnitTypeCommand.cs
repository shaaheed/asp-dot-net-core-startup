using System;

namespace Module.Systems.Domain
{
    public class UpdateUnitTypeCommand : CreateUnitTypeCommand
    {
        public Guid Id { get; set; }
    }
}
