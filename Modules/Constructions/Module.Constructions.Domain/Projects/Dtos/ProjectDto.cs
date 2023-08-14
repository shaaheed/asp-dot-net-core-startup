using Module.Constructions.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Constructions.Domain
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GuidIdNameDto Client { get; set; }
        public string Description { get; set; }
        public GuidIdNameDto UnitType { get; set; }
        public float PlotArea { get; set; }
        public GuidIdNameDto Unit { get; set; }
        public AddressDto Address { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Project, ProjectDto>> Selector()
        {
            return x => new ProjectDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Client = x.ClientId != null ? new GuidIdNameDto { Id = x.ClientId.Value, Name = x.Client.CompanyName } : null,
                UnitType = x.UnitTypeId != null ? new GuidIdNameDto { Id = x.UnitTypeId.Value, Name = x.UnitType.Name } : null,
                Unit = x.UnitId != null ? new GuidIdNameDto { Id = x.UnitId.Value, Name = x.Unit.Name } : null,
                PlotArea = x.PlotArea,
                Address = x.AddressId != null ? new AddressDto
                {
                    Id = x.AddressId.Value,
                    AddressLine1 = x.Address.AddressLine1,
                    AddressLine2 = x.Address.AddressLine2,
                    AddressLine3 = x.Address.AddressLine3,
                    AddressLine4 = x.Address.AddressLine4,
                    AddressLine5 = x.Address.AddressLine5,
                    Attention = x.Address.Attention,
                    City = x.Address.City,
                    Country = x.Address.CountryId != null ? new GuidIdNameDto { Id = x.Address.CountryId.Value, Name = x.Address.Country.Name } : null,
                    ContactName = x.Address.ContactName,
                    Phone = x.Address.Phone,
                    ZipCode = x.Address.ZipCode,
                    District = x.Address.DistrictId != null ? new GuidIdNameDto { Id = x.Address.DistrictId.Value, Name = x.Address.District.Name } : null,
                    StateOrProvince = x.Address.StateOrProvinceId != null ? new GuidIdNameDto { Id = x.Address.StateOrProvinceId.Value, Name = x.Address.StateOrProvince.Name } : null,
                } : null,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
