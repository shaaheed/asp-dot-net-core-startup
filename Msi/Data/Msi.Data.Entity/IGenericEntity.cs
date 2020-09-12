namespace Msi.Data.Entity
{
    public interface IGenericEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
