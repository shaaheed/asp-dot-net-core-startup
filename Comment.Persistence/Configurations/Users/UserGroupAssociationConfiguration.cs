
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class UserGroupAssociationConfiguration : IEntityTypeConfiguration<UserGroupAssociation>
    {
        public void Configure(EntityTypeBuilder<UserGroupAssociation> builder)
        {

           // builder.ToTable(nameof(UserGroupAssociation), SchemaConstants.USERS);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserGroupAssociations)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.UserGroupAssociations)
                .HasForeignKey(x => x.UserGroupId);

        }
    }
}
