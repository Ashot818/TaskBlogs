using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository;

public sealed class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostConfigurations());
        base.OnModelCreating(modelBuilder);
    }
}
