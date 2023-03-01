using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data;

public class ApplicationDbContext: DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    
    public DbSet<User> Users { get; set; }
}