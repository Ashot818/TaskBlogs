using BlogApi.Repository.Implementations;
using BlogApi.Repository.Interfaces;
using BlogApi.Repository.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApi.Repository.Extensions;

public static class RepositroyInjection
{
    public static void AddBlogDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"), b => b.MigrationsAssembly("BlogApi.Repository")));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
}
