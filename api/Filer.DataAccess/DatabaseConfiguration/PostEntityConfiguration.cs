using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filer.DataAccess.DatabaseConfiguration;

public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
{
    public void Configure(EntityTypeBuilder<PostEntity> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.HasData(new PostEntity{
            Id = 1, 
            Tag = "tag", 
            CreationDate = DateTimeOffset.MinValue,
            Description = "testDescription", 
            ImagePath = "testPath"}
        );
    }
}