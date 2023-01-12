using Microsoft.EntityFrameworkCore;
using RealEstateService.Models;

namespace RealEstateService.DbContexts;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<RealEstateType> RealEstateTypes { get; set; }
}