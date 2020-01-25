//
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Comment.Persistence.Configurations
//{
//    public class CommentConfiguration : IEntityTypeConfiguration<Domain.Entities.Comment>
//    {
//        public void Configure(EntityTypeBuilder<Domain.Entities.Comment> builder)
//        {

//            builder.ToTable(nameof(Domain.Entities.Comment), SchemaConstants.COMMENTS);
//            builder.HasKey(x => x.Id);
//            builder.Property(x => x.Content).IsRequired();

//        }
//    }
//}
