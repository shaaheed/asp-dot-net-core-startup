using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;

namespace Module.Integrations.Domain
{
    public class GetConnectorsQuery : Query<PagedCollection<ConnectorListItemDto>>
    {
    }
}
