//using Microsoft.EntityFrameworkCore;
//using Module.Identity.Entities;
//using Msi.Extensions.Persistence.Abstractions;

//namespace Module.Identity.Persistence.EntityFramework
//{
//    public class IdentityDataContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDataContext
//    {
//        public IdentityDataContext(DbContextOptions<IdentityDataContext> options)
//            : base(options)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//        }

//    }
//}
