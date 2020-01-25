
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Users.Entities;

namespace Comment.Persistence.Configurations
{
    public class UserResourceGroupConfiguration : IEntityTypeConfiguration<UserResourceGroup>
    {
        public void Configure(EntityTypeBuilder<UserResourceGroup> builder)
        {

            //builder.ToTable(nameof(UserResourceGroup), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserResourceGroups)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.ResourceGroup)
                .WithMany(x => x.UserResourceGroups)
                .HasForeignKey(x => x.ResourceGroupId);

        }
    }
}
