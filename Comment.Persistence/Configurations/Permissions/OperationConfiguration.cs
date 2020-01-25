using Module.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comment.Persistence.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {

            //builder.ToTable(nameof(Operation), SchemaConstants.PERMISSIONS);
            builder.HasKey(x => x.Id);

        }
    }
}
