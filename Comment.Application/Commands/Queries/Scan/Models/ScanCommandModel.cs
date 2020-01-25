using System.Collections.Generic;

namespace Comment.Application.Commands.Sync.Models
{
    public class ScanCommandModel
    {

        public ScanCommandModel()
        {
            Properties = new List<ScanCommandPropertyModel>();
        }

        public string Name { get; set; }
        public ICollection<ScanCommandPropertyModel> Properties { get; set; }
    }
}
