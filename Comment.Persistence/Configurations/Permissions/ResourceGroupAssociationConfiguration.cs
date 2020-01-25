
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class ResourceGroupAssociationConfiguration : IEntityTypeConfiguration<ResourceGroupAssociation>
    {
        public void Configure(EntityTypeBuilder<ResourceGroupAssociation> builder)
        {

            //builder.ToTable(nameof(ResourceGroupAssociation), SchemaConstants.PERMISSIONS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resource)
                .WithMany(x => x.ResourceGroupAssociations)
                .HasForeignKey(x => x.ResourceId);

            builder.HasOne(x => x.ResourceGroup)
                .WithMany(x => x.ResourceGroupAssociations)
                .HasForeignKey(x => x.ResourceGroupId);

        }
    }
}
