using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Integrations.Domain
{
    public class GetConnectionsQuery : Query<PagedCollection<ConnectionListItemDto>>
    {
    }
}
