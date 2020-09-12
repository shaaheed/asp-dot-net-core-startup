using Microsoft.AspNetCore.Identity;
using Msi.Data.Entity;

namespace Module.Users.Entities
{
	public class Role : IdentityRole<long>, IEntity
	{
		public string Code { get; set; }
		public string Description { get; set; }
	}
}