using System.Collections.Generic;
using System.Linq;
using Core.Interfaces.Entities;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.IdentityServer.Persistence.EntityFramework
{
    public class IdentityServerDataContext :
        ConfigurationDbContext<IdentityServerDataContext>, IPersistedGrantDbContext, IDataContext
    {
        public IdentityServerDataContext(DbContextOptions<IdentityServerDataContext> options, ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {
            storeOptions.DefaultSchema = "IdentityServer";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IEnumerable<TEntity> GetChangeTrackerEntities<TEntity>() where TEntity : class, IEntity
        {
            return ChangeTracker.Entries<TEntity>().Select(x => x.Entity);
        }

        public IQueryable<TEntity> GetEntities<TEntity>() where TEntity : class, IEntity
        {
            return Set<TEntity>().AsQueryable();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
        {
            return base.Set<TEntity>();
        }

        public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }

        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

        public DbSet<ApiSecret> ApiSecrets { get; set; }

        public DbSet<ApiScope> ApiScopes { get; set; }

        public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

        public DbSet<IdentityClaim> IdentityClaims { get; set; }

        public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }

        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }

        public DbSet<ClientScope> ClientScopes { get; set; }

        public DbSet<ClientSecret> ClientSecrets { get; set; }

        public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }

        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

        public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

        public DbSet<ClientClaim> ClientClaims { get; set; }

        public DbSet<ClientProperty> ClientProperties { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

    }
}
