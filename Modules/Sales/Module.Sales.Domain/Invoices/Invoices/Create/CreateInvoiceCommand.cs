using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateInvoiceCommand : InvoiceDocumentRequestDto<Invoice>, ICommand<Guid?>
    {
        public Guid? SalesPersonId { get; set; }
        public List<LineItemRequestDto> Items { get; set; }

        public override Invoice Map(Invoice entity = null)
        {
            entity = base.Map(entity);
            entity.SalesPersonId = SalesPersonId;
            return entity;
        }
    }
}
