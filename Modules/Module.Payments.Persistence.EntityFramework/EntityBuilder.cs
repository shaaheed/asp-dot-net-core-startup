using Microsoft.EntityFrameworkCore;
using Module.Payments.Data;
using Module.Payments.Entities;
using Msi.Extensions.Persistence.EntityFrameworkCore;

namespace Module.Payments.Persistence.EntityFramework
{
    public class EntityBuilder : IModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethodSeed().GetSeeds());
        }
    }
}
