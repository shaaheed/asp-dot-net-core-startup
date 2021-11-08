using Module.Integrations.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class CreateConnectionCommand : ICommand<long>
    {
        public Guid ConnectorId { get; set; }
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string TenantId { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountPhoto { get; set; }

        public virtual Connection Map(Connection entity = null)
        {
            entity = entity ?? new Connection();
            entity.ConnectorId = ConnectorId;
            entity.TokenType = TokenType;
            entity.AccessToken = AccessToken;

            entity.ExpiresIn = ExpiresIn;
            entity.RefreshToken = RefreshToken;
            entity.TenantId = TenantId;
            entity.AccountId = AccountId;
            entity.AccountName = AccountName;

            entity.AccountPhoto = AccountPhoto;
            return entity;
        }
    }
}
