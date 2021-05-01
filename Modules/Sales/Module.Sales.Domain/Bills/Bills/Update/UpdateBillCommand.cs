using System;

namespace Module.Sales.Domain
{
    public class UpdateBillCommand : CreateBillCommand
    {
        public Guid Id { get; set; }
    }
}
