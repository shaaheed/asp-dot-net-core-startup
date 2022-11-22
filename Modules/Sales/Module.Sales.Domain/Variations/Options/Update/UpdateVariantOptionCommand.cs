using System;

namespace Module.Sales.Domain
{
    public class UpdateVariantOptionCommand : CreateVariantOptionCommand
    {
        public Guid Id { get; set; }
    }
}
