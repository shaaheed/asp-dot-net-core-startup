using System;

namespace Module.Sales.Domain.Units
{
    public class UpdatePriceLevelCommand : CreatePriceLevelCommand
    {
        public Guid Id { get; set; }
    }
}
