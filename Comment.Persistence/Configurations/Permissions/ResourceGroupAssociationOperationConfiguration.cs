
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class ResourceGroupAssociationOperationConfiguration : IEntityTypeConfiguration<ResourceGroupAssociationOperation>
    {
        public void Configure(EntityTypeBuilder<ResourceGroupAssociationOperation> builder)
        {

            //builder.ToTable(nameof(ResourceGroupAssociationOperation), SchemaConstants.PERMISSIONS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ResourceGroupAssociation)
                .WithMany(x => x.ResourceGroupAssociationOperations)
                .HasForeignKey(x => x.ResourceGroupAssociationId);

            builder.HasOne(x => x.Operation)
               .WithMany(x => x.ResourceGroupAssociationOperations)
               .HasForeignKey(x => x.OperationId);

        }
    }
}
