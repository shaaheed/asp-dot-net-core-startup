﻿using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Products
{
    public class DeleteProductCommand : IDeleteCommand<bool>
    {
        public Guid Id { get; set; }
    }
}
