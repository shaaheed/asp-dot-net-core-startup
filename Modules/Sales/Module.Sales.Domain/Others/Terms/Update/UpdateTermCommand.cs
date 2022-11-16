using System;

namespace Module.Sales.Domain.Units
{
    public class UpdateTermCommand : CreateTermCommand
    {
        public Guid Id { get; set; }
    }
}
