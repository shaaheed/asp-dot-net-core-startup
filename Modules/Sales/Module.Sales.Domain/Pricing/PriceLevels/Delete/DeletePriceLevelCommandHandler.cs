﻿using Msi.Mediator.Abstractions;
using Module.Sales.Entities;
using Msi.Data.Abstractions;

namespace Module.Sales.Domain
{
    public class DeletePriceLevelCommandHandler : DeleteCommandHandler<PriceLevel, DeletePriceLevelCommand>
    {
        public DeletePriceLevelCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //
        }
    }
}
