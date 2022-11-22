using System;

namespace Module.Sales.Domain
{
    public class UpdateVariantCommand : CreateVariantCommand
    {
        public Guid Id { get; set; }
    }
}
