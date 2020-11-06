using Msi.Mediator.Abstractions;

namespace Module.Users.Domain
{
    public class GetUserQuery : IQuery<object>
    {
        public long Id { get; set; }
    }
}
