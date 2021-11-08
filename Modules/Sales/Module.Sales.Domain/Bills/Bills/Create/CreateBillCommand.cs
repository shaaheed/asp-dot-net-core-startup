using Module.Sales.Entities;
using Msi.Mediator.Abstractions;
using System;
using System.Collections.Generic;

namespace Module.Sales.Domain
{
    public class CreateBillCommand : InvoiceDocumentRequestDto<Bill>, ICommand<Guid?>
    {
        public List<LineItemRequestDto> Items { get; set; }
    }
}
