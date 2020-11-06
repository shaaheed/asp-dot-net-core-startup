using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Module.Core.Domain;
using System;

namespace Module.Sales.Domain.Qoutes
{
    public class GetQoutesQueryHandler : IQueryHandler<GetQoutesQuery, IEnumerable<QouteDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetQoutesQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<QouteDto>> Handle(GetQoutesQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.GetRepository<Qoute>()
                .AsQueryable()
                .Select(x => new QouteDto
                {
                    Id = x.Id,
                    Customer = x.CustomerId != null ? new IdNameDto<Guid>
                    {
                        Id = (Guid)x.CustomerId,
                        Name = x.Customer.FirstName
                    } : null,
                    Total = x.GrandTotal,
                    IssueDate = x.IssueDate
                })
                .ToList();
            return await Task.FromResult(results);
        }
    }
}
