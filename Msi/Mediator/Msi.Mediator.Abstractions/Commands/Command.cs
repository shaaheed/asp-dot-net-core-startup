namespace Msi.Mediator.Abstractions
{
    public abstract class Command<TEntity, TResponse> : ICommand<TResponse> where TEntity : new()
    {
        public int Source { get; set; }

        public virtual TEntity Map(TEntity entity = default(TEntity))
        {
            if (entity == null) return new TEntity();

            return entity;
        }
    }
}
