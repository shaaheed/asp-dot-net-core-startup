using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class Tax : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public float Rate { get; set; }
    }
}
