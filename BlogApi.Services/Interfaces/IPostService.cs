using BlogApi.Services.DTO;

namespace BlogApi.Services.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostDTO>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<PostDTO>> GetIsDeletedPostsAsync(CancellationToken cancellationToken);
    Task<PostDTO?> GetPostByIdAsync(int id, CancellationToken cancellationToken);
    Task AddPostAsync(PostDTO PostDTO, CancellationToken cancellationToken);
    Task UpdatePostAsync(PostDTO PostDTO, CancellationToken cancellationToken);
    Task DeletePostAsync(int id, CancellationToken cancellationToken);
    Task RestorePostAsync(int id, CancellationToken cancellationToken);
}
