using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filer.DataAccess.DatabaseConfiguration;

public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
{
    public void Configure(EntityTypeBuilder<PostEntity> builder)
    {
        builder.HasOne(p => p.UserEntity).WithMany(u => u.PostEntities).OnDelete(DeleteBehavior.Cascade);
    }
}