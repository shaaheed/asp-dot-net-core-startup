using System;

namespace Module.Sales.Domain
{
    public class UpdateUnitCommand : CreateUnitCommand
    {
        public Guid Id { get; set; }
    }
}
