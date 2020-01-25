using Core.Interfaces.Entities;

namespace Module.Users.Entities
{
    public class ResourceOperation : BaseEntity
    {

        public long ResourceId { get; set; }
        public Resource Resource { get; set; }

        public long OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
