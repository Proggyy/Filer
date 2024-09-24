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
        modelBuilder.Entity<PostEntity>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.Entity<PostEntity>().HasData(new PostEntity{Id = 1, Tag = "tag"});
    }
}
