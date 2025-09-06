using Microsoft.EntityFrameworkCore;

namespace GeekStore.ProductApi.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}