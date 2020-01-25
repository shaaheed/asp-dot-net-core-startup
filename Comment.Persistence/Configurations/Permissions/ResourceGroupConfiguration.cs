
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class ResourceGroupConfiguration : IEntityTypeConfiguration<ResourceGroupAssociation>
    {
        public void Configure(EntityTypeBuilder<ResourceGroupAssociation> builder)
        {

            //builder.ToTable(nameof(ResourceGroupAssociation), SchemaConstants.PERMISSIONS);
            builder.HasKey(x => x.Id);

        }
    }
}
