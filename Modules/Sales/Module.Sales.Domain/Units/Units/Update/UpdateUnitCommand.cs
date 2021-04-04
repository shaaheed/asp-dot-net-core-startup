using System;

namespace Module.Sales.Domain.Units
{
    public class UpdateUnitCommand : CreateUnitCommand
    {
        public Guid Id { get; set; }
    }
}
