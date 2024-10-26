using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filer.DataAccess.DatabaseConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasData(new UserEntity{
            Id = Guid.NewGuid(),
            Login = "Test",
            UserName = "Test",
            PasswordHash = "11111"
            }
        );
    }
}