using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Msi.Data.EntityFrameworkCore;
using System.Collections.Generic;

namespace Module.IdentityServer.Persistence.EntityFramework
{
    public class EntityBuilder : IModelBuilder
    {
        public string DefaultSchema { get; } = "IdentityServer";

        public void Build(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.Entity<DeviceFlowCodes>().HasNoKey();
            modelBuilder.Entity<PersistedGrant>().HasNoKey();

            modelBuilder.Entity<ApiResource>()
                .HasData(new ApiResource
                {
                    Id = 1,
                    Enabled = true,
                    DisplayName = "WEBAPI",
                    Name = "webapi",
                });

            modelBuilder.Entity<ApiScope>()
                .HasData(new List<ApiScope> {
                    new ApiScope {
                        Id = 1,
                        ApiResourceId = 1,
                        Name = "webapi"
                    },
                    new ApiScope {
                        Id = 2,
                        ApiResourceId = 1,
                        //Name = IdentityServerConstants.StandardScopes.OpenId
                    }
                });

            modelBuilder.Entity<Client>()
                .HasData(GetClients());

            modelBuilder.Entity<ClientSecret>()
                .HasData(new ClientSecret
                {
                    Id = 1,
                    ClientId = 1,
                    Value = "root_client_super_secret".ToSha256()
                });

            modelBuilder.Entity<ClientGrantType>()
                .HasData(new List<ClientGrantType> {
                    new ClientGrantType {
                        Id = 1,
                        ClientId = 1,
                        GrantType = IdentityServer4.Models.GrantType.ResourceOwnerPassword
                    }
                });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>()
                .HasData(new ClientPostLogoutRedirectUri
                {
                    Id = 1,
                    ClientId = 1,
                    // where to redirect to after logout
                    PostLogoutRedirectUri = "http://localhost:4200/signout-callback-oidc"
                });

            modelBuilder.Entity<ClientRedirectUri>()
                .HasData(new ClientRedirectUri
                {
                    Id = 1,
                    ClientId = 1,
                    // where to redirect to after login
                    RedirectUri = "http://localhost:4200/signin-oidc"
                });

            modelBuilder.Entity<ClientScope>()
                .HasData(new List<ClientScope> {
                    new ClientScope {
                        Id = 1,
                        ClientId = 1,
                        //Scope = IdentityServerConstants.StandardScopes.OpenId
                    },
                    new ClientScope {
                        Id = 2,
                        ClientId = 1,
                        //Scope = IdentityServerConstants.StandardScopes.Profile
                    },
                    new ClientScope {
                        Id = 3,
                        ClientId = 1,
                        Scope = "webapi"
                    }
            });

        }

        private List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            Client client1 = new IdentityServer4.Models.Client
            {
                ClientId = "root_client",
                ClientName = "root_client",
                Enabled = true,
                RefreshTokenUsage = IdentityServer4.Models.TokenUsage.OneTimeOnly,
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,

                // This client does not need a secret to request tokens from the token endpoint.
                RequireClientSecret = false,
            }.ToEntity();

            client1.Id = 1;

            clients.Add(client1);
            return clients;
        }
    }
}
