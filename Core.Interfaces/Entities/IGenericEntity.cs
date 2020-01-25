namespace Core.Interfaces.Entities
{
    public interface IGenericEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
