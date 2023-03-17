using Microsoft.EntityFrameworkCore;
using EstateManagement.Models;
namespace EstateManagement.DbContexts;

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
    
    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<RealEstateType> RealEstateTypes { get; set; }
    public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }
}