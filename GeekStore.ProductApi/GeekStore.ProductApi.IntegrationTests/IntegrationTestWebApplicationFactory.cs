using GeekStore.ProductApi.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;

namespace GeekStore.ProductApi.IntegrationTests;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    
    private readonly PostgreSqlContainer _postgresContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("geekstore-product")
        .WithUsername("geekstore_product")
        .WithPassword("geekstore_product")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseNpgsql(_postgresContainer.GetConnectionString());
            });
            
            builder.UseEnvironment("Development");

        });
        base.ConfigureWebHost(builder);
    }
    
    
    public Task InitializeAsync()
    {
        return _postgresContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _postgresContainer.StopAsync();
    }
}