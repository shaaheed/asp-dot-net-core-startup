using Module.Integrations.Entities;
using Msi.Mediator.Abstractions;
using System;

namespace Module.Integrations.Domain
{
    public class CreateConnectorCommand : ICommand<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProviderId { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
        public string ApiKey { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }

        public virtual Connector Map(Connector entity = null)
        {
            entity = entity ?? new Connector();
            entity.Name = Name;
            entity.Description = Description;
            entity.ProviderId = ProviderId;

            entity.State = State;
            entity.Scope = Scope;
            entity.ApiKey = ApiKey;
            entity.ClientId = ClientId;
            entity.ClientSecret = ClientSecret;

            entity.RedirectUri = RedirectUri;
            return entity;
        }
    }
}
