
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class UserGroupResourceConfiguration : IEntityTypeConfiguration<UserGroupResource>
    {
        public void Configure(EntityTypeBuilder<UserGroupResource> builder)
        {

            //builder.ToTable(nameof(UserGroupResource), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.UserGroupResources)
                .HasForeignKey(x => x.UserGroupId);

            builder.HasOne(x => x.Resource)
                .WithMany(x => x.UserGroupResources)
                .HasForeignKey(x => x.ResourceId);

        }
    }
}
