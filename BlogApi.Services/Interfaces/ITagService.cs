using BlogApi.Services.DTO;

namespace BlogApi.Services.Interfaces;

public interface ITagService
{
    Task<IEnumerable<TagDTO>> GetAllTagsAsync(CancellationToken cancellationToken);

    
    Task<TagDTO?> GetTagByIdAsync(int id, CancellationToken cancellationToken);

 
    Task AddTagAsync(TagDTO tagDTO, CancellationToken cancellationToken);

    Task UpdateTagAsync(TagDTO tagDTO, CancellationToken cancellationToken);

 
    Task DeleteTagAsync(int id, CancellationToken cancellationToken);
}

