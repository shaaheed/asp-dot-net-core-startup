using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Module.Sales.Domain.Bills
{
    public class CreateBillCommand : BaseInvoiceRequestDto<Bill>, ICommand<long>
    {
        public List<InvoiceLineItemRequestDto> Items { get; set; }

        public override Bill Map(Bill entity = null)
        {
            entity = base.Map(entity);
            entity.OrderNumber = OrderNumber;
            entity.SupplierId = ContactId;
            entity.AdjustmentText = AdjustmentText;
            entity.AdjustmentAmount = AdjustmentAmount;
            return entity;
        }
    }
}
