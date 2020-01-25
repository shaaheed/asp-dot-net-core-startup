
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            builder.ToTable(nameof(Permission), "SchemaConstants.PERMISSIONS");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resource).WithOne(x => x.Permission);
            builder.HasOne(x => x.Operation);

        }
    }
}
