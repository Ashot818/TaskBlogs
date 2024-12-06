using AutoMapper;
using BlogApi.Models;
using BlogApi.Services.DTO;

namespace BlogApi.Services.MappingProfiles;

public sealed class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<PostDTO, Post>()
            .ForMember(x => x.Tags, dest => dest.MapFrom(x => x.Tags));
        CreateMap<Post, PostDTO>();
    }
}
