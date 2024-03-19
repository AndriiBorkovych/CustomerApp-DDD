using CustomerApp.Application.Contracts;
using CustomerApp.Infrastructure.Data;
using CustomerApp.Infrastructure.Data.Interceptors;
using CustomerApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApp.Infrastructure;

public static class DependencyRegistration
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DinnerDbContext>(opt =>
            opt.UseSqlServer(
                "Server=localhost;Database=DinnerDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true"));
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IMenuRepository, MenuRepository>();
    }
}