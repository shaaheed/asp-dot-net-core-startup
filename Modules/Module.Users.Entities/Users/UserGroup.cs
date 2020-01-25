using Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Module.Users.Entities
{
    public class UserGroup : BaseEntity
    {

        public UserGroup()
        {
            UserGroupAssociations = new HashSet<UserGroupAssociation>();
            UserGroupResources = new HashSet<UserGroupResource>();
            UserGroupResourceGroups = new HashSet<UserGroupResourceGroup>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<UserGroupAssociation> UserGroupAssociations { get; protected set; }
        public ICollection<UserGroupResource> UserGroupResources { get; protected set; }
        public ICollection<UserGroupResourceGroup> UserGroupResourceGroups { get; protected set; }
    }
}
