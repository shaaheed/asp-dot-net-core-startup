using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class ResourceGroupAssociationOperation : BaseEntity
    {
        public long ResourceGroupAssociationId { get; set; }
        public ResourceGroupAssociation ResourceGroupAssociation { get; set; }

        public long OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
