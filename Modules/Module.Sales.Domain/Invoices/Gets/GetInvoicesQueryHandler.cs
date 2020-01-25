﻿using Core.Infrastructure.Queries;
using Module.Sales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Sales.Domain.Invoices
{
    public class GetInvoicesQueryHandler : IQueryHandler<GetInvoicesQuery, IEnumerable<InvoiceDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoicesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.GetRepository<Invoice>()
                .AsQueryable()
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Customer = x.CustomerId != null ? new InvoiceCustomerDto
                    {
                        Id = (long)x.CustomerId,
                        Name = x.Customer.FirstName
                    } : null,
                    AmountDue = x.AmountDue,
                    Total = x.GrandTotal,
                    IssueDate = x.IssueDate,
                    Status = x.Status.ToString()
                })
                .ToList();
            return products;
        }
    }
}
