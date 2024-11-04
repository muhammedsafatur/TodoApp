using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Repository.Context;
using Todo.Repository.Repositories.Abstract;
using Todo.Repository.Repositories.Concretes;

namespace Todo.Repository;

public static class RepositoryDependencies
{

    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITaskRepository, EfTaskRepository>();
        services.AddScoped<ICategoryRepository,EfCategoryRepository>();
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}