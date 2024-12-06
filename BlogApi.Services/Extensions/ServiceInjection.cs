using BlogApi.Services.Implementations;
using BlogApi.Repository.Extensions;
using BlogApi.Services.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using BlogApi.Services.Interfaces;

namespace BlogApi.Services.Extensions;

public static class ServiceInjection
{
    public static void AddLocalServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddMappingProfiles(services);
        services.AddBlogDbContext(configuration);
        services.AddRepositories();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ITagService, TagService>();
    }

    private static void AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(m =>
        {
            m.AddProfile<PostProfile>();
            m.AddProfile<TagProfile>();
        }, Assembly.GetExecutingAssembly());
    }
}
