using Core.Interfaces.Entities;
using Module.Permissions.Entities;

namespace Module.Users.Entities
{
	public class RolePermission : IEntity
	{
		public long Id { get; set; }

		public long RoleId { get; set; }
		public Role Role { get; set; }

		public string PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}