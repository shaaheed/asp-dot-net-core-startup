﻿using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain.Qoutes
{
    public class GetQouteQueryHandler : IQueryHandler<GetQouteQuery, QouteDetailsDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetQouteQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<QouteDetailsDto> Handle(GetQouteQuery request, CancellationToken cancellationToken)
        {
            //var result = _unitOfWork.GetRepository<Qoute>()
            //    .AsQueryable()
            //    .Select(x => new QouteDetailsDto
            //    {
            //        Id = x.Id,
            //        Customer = x.Customer != null ? new CustomerDto
            //        {
            //            Id = (Guid)x.CustomerId,
            //            Name = x.Customer.FirstName,
            //            Contact = x.Customer.Contact,
            //            Email = x.Customer.Email,
            //            Mobile = x.Customer.Mobile
            //        } : null,
            //        Total = x.GrandTotal,
            //        Items = x.QouteLineItems.Select(i => new QouteLineItemDto
            //        {
            //            Id = i.Id,
            //            Name = i.LineItem.Name,
            //            Description = i.LineItem.Description,
            //            ProductId = i.LineItem.ProductId,
            //            Quantity = i.LineItem.Quantity,
            //            Subtotal = i.LineItem.Subtotal,
            //            Total = i.LineItem.Total,
            //            UnitPrice = i.LineItem.UnitPrice
            //        }),
            //        IssueDate = x.IssueDate,
            //        Currency = x.Currency != null ? new IdNameDto<Guid>
            //        {
            //            Id = (Guid)x.CurrencyId,
            //            Name = x.Currency.Name
            //        } : null,
            //        ExpiresOn = x.ExpiresOn,
            //        Memo = x.Memo,
            //        TotalConvertedInvoice = x.TotalConvertedInvoice
            //    })
            //    .FirstOrDefault(x => x.Id == request.Id);
            //return await Task.FromResult(result);
            return null;
        }
    }
}
