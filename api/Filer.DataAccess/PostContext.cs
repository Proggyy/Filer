using Filer.DataAccess.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Filer.DataAccess;
public class PostContext : DbContext
{
    public DbSet<PostEntity> PostEntities { get; set; }
    public PostContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
    }
}
