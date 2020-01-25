
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Users.Entities;

namespace Comment.Persistence.Configurations
{
    public class UserResourceOperationConfiguration : IEntityTypeConfiguration<UserResourceOperation>
    {
        public void Configure(EntityTypeBuilder<UserResourceOperation> builder)
        {

            //builder.ToTable(nameof(UserResourceOperation), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserResource)
                .WithMany(x => x.UserResourceOperations)
                .HasForeignKey(x => x.UserResourceId);

            builder.HasOne(x => x.Operation)
                .WithMany(x => x.UserResourceOperations)
                .HasForeignKey(x => x.OperationId);

        }
    }
}
