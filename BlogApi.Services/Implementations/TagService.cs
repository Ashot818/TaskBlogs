using AutoMapper;
using BlogApi.Models;
using BlogApi.Repository.UoW;
using BlogApi.Services.DTO;
using BlogApi.Services.Interfaces;

namespace BlogApi.Services.Implementations
{
    internal sealed class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDTO>> GetAllTagsAsync(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TagRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TagDTO>>(result);
        }

        public async Task<TagDTO?> GetTagByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TagRepository.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return _mapper.Map<TagDTO>(result);
        }

        public async Task AddTagAsync(TagDTO tagDTO, CancellationToken cancellationToken)
        {
            var mapping = _mapper.Map<Tag>(tagDTO);
            await _unitOfWork.TagRepository.AddAsync(mapping, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateTagAsync(TagDTO tagDTO, CancellationToken cancellationToken)
        {
            var mapping = _mapper.Map<Tag>(tagDTO);
            _unitOfWork.TagRepository.Update(mapping);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTagAsync(int id, CancellationToken cancellationToken)
        {
            var tag = await _unitOfWork.TagRepository.FirstOrDefaultWithTrackingAsync(x => x.Id == id, cancellationToken)
                ?? throw new KeyNotFoundException($"Tag with ID {id} not found.");

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
