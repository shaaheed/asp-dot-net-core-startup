using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class TermDto : GuidIdNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public float Days { get; set; }
        public bool IsActive { get; set; }

        public static Expression<Func<Term, TermDto>> Selector()
        {
            return x => new TermDto
            {
                Id = x.Id,
                Name = x.Name,
                Days = x.Days,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
