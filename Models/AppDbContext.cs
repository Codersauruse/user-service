using Microsoft.EntityFrameworkCore;

namespace user_service.Models;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<AppUser> AppUsers { get; set; }    
}