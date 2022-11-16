using Module.Sales.Entities;
using Module.Systems.Domain;
using System;
using System.Linq.Expressions;

namespace Module.Sales.Domain.Units
{
    public class TermDto : GuidIdNameDto
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<Term, TermDto>> Selector()
        {
            return x => new TermDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
