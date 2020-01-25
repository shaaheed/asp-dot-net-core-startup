
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class UserGroupResourceGroupConfiguration : IEntityTypeConfiguration<UserGroupResourceGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroupResourceGroup> builder)
        {

            //builder.ToTable(nameof(UserGroupResourceGroup), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.UserGroupResourceGroups)
                .HasForeignKey(x => x.UserGroupId);

            builder.HasOne(x => x.ResourceGroup)
                .WithMany(x => x.UserGroupResourceGroups)
                .HasForeignKey(x => x.ResourceGroupId);

        }
    }
}
