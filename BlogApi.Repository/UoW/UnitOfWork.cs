using BlogApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository.UoW;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly BlogDbContext _dbContext;
    
    public ITagRepository TagRepository { get; set; }
    public IPostRepository PostRepository { get; set; }

    public UnitOfWork(
        BlogDbContext dbContext,
        ITagRepository tagRepository,
        IPostRepository postRepository)
    {
        _dbContext = dbContext;
        TagRepository = tagRepository;
        PostRepository = postRepository;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);
}
