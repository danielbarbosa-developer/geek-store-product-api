using GeekStore.ProductApi.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.ProductApi.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}