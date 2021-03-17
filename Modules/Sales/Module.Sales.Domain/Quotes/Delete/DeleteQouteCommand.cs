using Msi.Mediator.Abstractions;
using System;

namespace Module.Sales.Domain.Qoutes
{
    public class DeleteQouteCommand : ICommand<long>
    {
        public Guid Id { get; set; }
    }
}
