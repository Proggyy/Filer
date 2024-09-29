using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filer.DataAccess.DatabaseConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.HasData(new UserEntity{
            Id = 1,
            Login = "Test",
            UserName = "Test"
            }
        );
    }
}