using System.Reflection;
using Mapster;
using MapsterMapper;

namespace CustomerApp.API.Common.MappingConfigurations;

public static class RegisterMapping
{
    public static void AddMapster(this IServiceCollection services)
    {
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(mappingConfig);
        services.AddScoped<IMapper, ServiceMapper>();
    }
}