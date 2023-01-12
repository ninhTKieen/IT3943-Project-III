using DeviceManagement.Data;
using DeviceManagement.Services;
using Microsoft.OpenApi.Models;

namespace DeviceManagement.IOC;

public static class ExtraConfigurations
{
    public static async Task Register(this IServiceCollection services, IConfiguration configuration)
    {
        //configure
        ConfigureSwagger(services, configuration);
        
        
        //grpc
        services.AddGrpc(options =>
        {
            options.EnableDetailedErrors = true;
        });
        
        //mapper
        services.AddDbContext<ApplicationDbContext>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        //add service
        services.AddScoped<DeviceService>();
        
    }

    private static void ConfigureSwagger(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Device Management API", Version = "v1" });
        });
    }
}