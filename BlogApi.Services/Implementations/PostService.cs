using AutoMapper;
using BlogApi.Models;
using BlogApi.Repository.UoW;
using BlogApi.Services.DTO;
using BlogApi.Services.Interfaces;

namespace BlogApi.Services.Implementations;

internal sealed class PostService(IUnitOfWork unitOfWork, IMapper mapper) : IPostService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<PostDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PostRepository.GetAllAsync(cancellationToken, x => x.Tags);

        return _mapper.Map<IEnumerable<PostDTO>>(result);
    }

    public async Task<IEnumerable<PostDTO>> GetIsDeletedPostsAsync(CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PostRepository.GetWhereAsync(x => x.IsDeleted, cancellationToken);

        return _mapper.Map<IEnumerable<PostDTO>>(result);
    }

    public async Task<PostDTO?> GetPostByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PostRepository.FirstOrDefaultAsync(x => x.Id == id, cancellationToken, x => x.Tags);

        return _mapper.Map<PostDTO>(result);
    }

    public async Task AddPostAsync(PostDTO postDTO, CancellationToken cancellationToken)
    {
        var mapping = _mapper.Map<Post>(postDTO);

        if (mapping.Tags != null && mapping.Tags.Any())
        {
            Console.WriteLine($"Tags count: {mapping.Tags.Count}");
        }

        await _unitOfWork.PostRepository.AddAsync(mapping, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }


    public async Task UpdatePostAsync(PostDTO PostDTO, CancellationToken cancellationToken)
    {
        var mapping = _mapper.Map<Post>(PostDTO);

        _unitOfWork.PostRepository.Update(mapping);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePostAsync(int id, CancellationToken cancellationToken)
    {
        var postDto = await _unitOfWork.PostRepository.FirstOrDefaultWithTrackingAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"PostDTO with ID {id} not found.");

        postDto.IsDeleted = true;

        _unitOfWork.PostRepository.Update(postDto);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task RestorePostAsync(int id, CancellationToken cancellationToken)
    {
        var postDto = await _unitOfWork.PostRepository.FirstOrDefaultWithTrackingAsync(x => x.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"PostDTO with ID {id} not found.");

        postDto.IsDeleted = false;

        _unitOfWork.PostRepository.Update(postDto);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
