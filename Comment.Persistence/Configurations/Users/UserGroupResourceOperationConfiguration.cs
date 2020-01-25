
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class UserGroupResourceOperationConfiguration : IEntityTypeConfiguration<UserGroupResourceOperation>
    {
        public void Configure(EntityTypeBuilder<UserGroupResourceOperation> builder)
        {

            //builder.ToTable(nameof(UserGroupResourceOperation), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserGroupResource)
                .WithMany(x => x.UserGroupResourceOperations)
                .HasForeignKey(x => x.UserGroupResourceId);

            builder.HasOne(x => x.Operation)
                .WithMany(x => x.UserGroupResourceOperations)
                .HasForeignKey(x => x.OperationId);

        }
    }
}
