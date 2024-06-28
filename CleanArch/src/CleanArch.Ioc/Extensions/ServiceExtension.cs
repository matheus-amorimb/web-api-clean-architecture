using CleanArch.Data.Context;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Ioc.Extensions;

public static class ServiceExtension
{
    public static void AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AppDbContext>(builder =>
        {
            var postgresConnectionString = configuration.GetConnectionString("DefaultConnectionString");
            builder.UseNpgsql(postgresConnectionString);
        });
    }

    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
    }

    public static void AddServices(this IServiceCollection serviceCollection)
    {
    }
}
