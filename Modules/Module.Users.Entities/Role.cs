using Core.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace Module.Users.Entities
{
	public class Role : IdentityRole<long>, IEntity
	{
		public string Code { get; set; }
		public string Description { get; set; }
	}
}