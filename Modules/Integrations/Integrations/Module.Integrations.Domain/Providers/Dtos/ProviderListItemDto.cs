using Module.Integrations.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Integrations.Domain
{
    public class ProviderListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static Expression<Func<Provider, ProviderListItemDto>> Selector()
        {
            return x => new ProviderListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            };
        }
    }
}
