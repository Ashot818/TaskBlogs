using BlogApi.Repository.Interfaces;

namespace BlogApi.Repository.UoW;

public interface IUnitOfWork
{
    public ITagRepository TagRepository { get; }
    public IPostRepository PostRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
