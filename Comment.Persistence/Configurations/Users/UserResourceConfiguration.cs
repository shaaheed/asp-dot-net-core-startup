
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class UserResourceConfiguration : IEntityTypeConfiguration<UserResource>
    {
        public void Configure(EntityTypeBuilder<UserResource> builder)
        {

            //builder.ToTable(nameof(UserResource), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resource)
                .WithMany(x => x.UserResources)
                .HasForeignKey(x => x.ResourceId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserResources)
                .HasForeignKey(x => x.UserId);

        }
    }
}
