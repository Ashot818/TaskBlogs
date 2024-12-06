using BlogApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(p => p.Tags)
            .WithMany(t => t.Posts)
            .UsingEntity<Dictionary<string, object>>(
                "PostTag",
                j => j
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasPrincipalKey(nameof(Tag.Id)),
                j => j
                    .HasOne<Post>()
                    .WithMany()
                    .HasForeignKey("PostId")
                    .HasPrincipalKey(nameof(Post.Id)),
                j =>
                {
                    j.HasKey("PostId", "TagId");
                    j.ToTable("PostTag");
                });
    }
}
