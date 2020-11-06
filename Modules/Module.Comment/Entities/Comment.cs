using Msi.Data.Entity;
using System.Collections.Generic;

namespace Module.Comment.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public long UserId { get; set; }

        public Comment Parent { get; set; }

        ICollection<Comment> Replies { get; set; }
    }
}
