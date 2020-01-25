
using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {

            //builder.ToTable(nameof(Resource), SchemaConstants.PERMISSIONS);
            builder.HasKey(x => x.Id);

        }
    }
}
