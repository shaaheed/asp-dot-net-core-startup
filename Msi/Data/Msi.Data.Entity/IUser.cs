namespace Msi.Data.Entity
{
    public interface IUser<T> : IEntity
    {
        public T Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
