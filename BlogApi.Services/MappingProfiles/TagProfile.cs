using AutoMapper;
using BlogApi.Models;
using BlogApi.Services.DTO;

namespace BlogApi.Services.MappingProfiles;

public sealed class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagDTO, Tag>();
        CreateMap<Tag, TagDTO>();
    }
}
