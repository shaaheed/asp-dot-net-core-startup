using Module.Permissions.Entities;
using Msi.Data.Entity;
using System;

namespace Module.Accounts.Entities
{
	public class RolePermission : BaseEntity
	{
		public Guid RoleId { get; set; }
		public Role Role { get; set; }

		public Guid PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}