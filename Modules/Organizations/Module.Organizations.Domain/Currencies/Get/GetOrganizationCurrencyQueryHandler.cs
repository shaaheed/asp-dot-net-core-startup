﻿using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Organizations.Domain
{
    public class GetOrganizationCurrencyQueryHandler : IQueryHandler<GetOrganizationCurrencyQuery, OrganizationCurrencyDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOrganizationCurrencyQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<OrganizationCurrencyDto> Handle(GetOrganizationCurrencyQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.GetAsync(x => x.Id == request.Id, OrganizationCurrencyDto.Selector(), cancellationToken);
        }
    }
}
