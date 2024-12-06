using BlogApi.Models;
using BlogApi.Repository.Interfaces;

namespace BlogApi.Repository.Implementations;

internal sealed class TagRepository(BlogDbContext dbContext) : BaseRepository<Tag>(dbContext), ITagRepository
{
}
