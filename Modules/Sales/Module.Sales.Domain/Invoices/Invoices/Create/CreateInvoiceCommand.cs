using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommand : BaseInvoiceRequestDto<Invoice>, ICommand<long>
    {
        public Guid? SalesPersonId { get; set; }
        public List<InvoiceLineItemRequestDto> Items { get; set; }

        public override Invoice Map(Invoice entity = null)
        {
            entity = base.Map(entity);
            entity.SalesPersonId = SalesPersonId;
            entity.OrderNumber = OrderNumber;
            entity.CustomerId = ContactId;
            entity.AdjustmentText = AdjustmentText;
            entity.AdjustmentAmount = AdjustmentAmount;
            return entity;
        }
    }
}
