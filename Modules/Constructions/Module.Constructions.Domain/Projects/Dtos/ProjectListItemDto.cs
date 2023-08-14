using Module.Constructions.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Constructions.Domain
{
    public class ProjectListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GuidIdNameDto Client { get; set; }
        public float PlotArea { get; set; }
        public GuidIdNameDto Unit { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Project, ProjectListItemDto>> Selector()
        {
            return x => new ProjectListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Client = x.ClientId != null ? new GuidIdNameDto { Id = x.ClientId.Value, Name = x.Client.CompanyName } : null,
                Unit = x.UnitId != null ? new GuidIdNameDto { Id = x.UnitId.Value, Name = x.Unit.Name } : null,
                PlotArea = x.PlotArea,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
