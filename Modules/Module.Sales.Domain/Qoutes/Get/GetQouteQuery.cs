using Core.Infrastructure.Queries;

namespace Module.Sales.Domain.Qoutes
{
    public class GetQouteQuery : IQuery<QouteDetailsDto>
    {
        public long Id { get; set; }
    }
}
