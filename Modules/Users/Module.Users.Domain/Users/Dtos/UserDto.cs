using Module.Users.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Users.Domain
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

        public static Expression<Func<User, UserDto>> Selector()
        {
            return x => new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                Email = x.Email,
                Mobile = x.Mobile,
                CreatedAt = x.CreatedAt
            };
        }
    }
}
