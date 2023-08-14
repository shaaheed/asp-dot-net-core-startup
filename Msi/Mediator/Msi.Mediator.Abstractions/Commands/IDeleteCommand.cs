using System;

namespace Msi.Mediator.Abstractions
{
    public interface IDeleteCommand<TResponse> : ICommand<TResponse>
    {
        public Guid Id { get; set; }
    }
}
