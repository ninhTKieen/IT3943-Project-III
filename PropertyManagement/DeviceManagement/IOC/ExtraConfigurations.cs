using System.Text;
using DeviceManagement.Data;
using DeviceManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace DeviceManagement.IOC;

public static class ExtraConfigurations
{
    public static async Task Register(this IServiceCollection services, IConfiguration configuration)
    {
        //configure
        ConfigureSwagger(services);
        ConfigureAuthentication(services, configuration);
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
        services.AddScoped<MaintenanceService>();
        services.AddScoped<CategoryService>();
    }

    
    private static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(configuration.GetSection("Jwt.Secret").ToString() ?? throw new InvalidOperationException())),
                };
            });
    }
    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Service API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
    
    
}