using Module.Systems.Entities;

namespace Module.Sales.Entities
{
    public class SalesOrder : OrganizationCodeNameEntity
    {
        public SalesOrderType Type { get; set; } = SalesOrderType.SalesOrder;
    }
}
