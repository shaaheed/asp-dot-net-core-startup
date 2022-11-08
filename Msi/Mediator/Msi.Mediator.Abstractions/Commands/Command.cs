namespace Msi.Mediator.Abstractions
{
    public abstract class Command<TResponse> : ICommand<TResponse>
    {
        public int Source { get; set; }

        //public virtual TEntity Map(TEntity entity = default(TEntity))
        //{
        //    if (entity == null) return new TEntity();

        //    return entity;
        //}
    }
}
