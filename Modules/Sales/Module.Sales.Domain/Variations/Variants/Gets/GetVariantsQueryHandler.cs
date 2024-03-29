﻿using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;
using Msi.Utilities.Filter;
using System.Linq;
using Module.Sales.Entities;
using Module.Systems.Domain;
using Module.Systems.Entities;

namespace Module.Sales.Domain
{
    public class GetVariantsQueryHandler : IQueryHandler<GetVariantsQuery, PagedCollection<VariantListItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetVariantsQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedCollection<VariantListItemDto>> Handle(GetVariantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ListAsync(VariantListItemDto.Selector(), request.FilterOptions, cancellationToken);

            var typeIds = result.Items.Select(x => x.Id);
            var baseUnits = _unitOfWork.GetRepository<Unit>()
                .Where(x => typeIds.Contains(x.TypeId) && x.IsBaseUnit)
                .Select(x => new { Id = x.Id, Name = x.Name, TypeId = x.TypeId })
                .ToList();


            foreach (var item in result.Items)
            {
                var baseUnit = baseUnits.FirstOrDefault(x => x.TypeId == item.Id);
                if (baseUnit != null)
                {
                    item.BaseUnit = new GuidIdNameDto { Id = baseUnit.Id, Name = baseUnit.Name };
                }
            }

            return result;
        }
    }
}
