using System;

namespace Module.Systems.Domain
{
    public class UpdateUnitCommand : CreateUnitCommand
    {
        public Guid Id { get; set; }
    }
}
