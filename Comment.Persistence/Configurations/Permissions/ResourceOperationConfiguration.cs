
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class ResourceOperationConfiguration : IEntityTypeConfiguration<ResourceOperation>
    {
        public void Configure(EntityTypeBuilder<ResourceOperation> builder)
        {

            //builder.ToTable(nameof(ResourceOperation), SchemaConstants.PERMISSIONS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resource)
                .WithMany(x => x.ResourceOperations)
                .HasForeignKey(x => x.ResourceId);

            builder.HasOne(x => x.Operation)
                .WithMany(x => x.ResourceOperations)
                .HasForeignKey(x => x.OperationId);

        }
    }
}
