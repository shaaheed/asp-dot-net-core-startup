namespace Msi.Mediator.Abstractions
{
    public interface ICreateCommand<TEntity, TResponse> : ICommand<TResponse>
    {
        TEntity Map(TEntity entity = default);
    }
}
