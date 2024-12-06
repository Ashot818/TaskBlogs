using BlogApi.Models;
using BlogApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository.Implementations;

internal sealed class PostRepository(BlogDbContext dbContext) : BaseRepository<Post>(dbContext), IPostRepository
{
}
