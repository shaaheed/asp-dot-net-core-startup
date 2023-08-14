using Module.Systems.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(ProjectMaterialMixRatio), Schema = SchemaConstants.Constructions)]
    public class ProjectMaterialMixRatio : OrganizationNameEntity
    {
        
    }
}
