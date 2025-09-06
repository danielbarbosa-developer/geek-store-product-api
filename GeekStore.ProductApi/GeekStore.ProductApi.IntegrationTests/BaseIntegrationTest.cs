using System.Net;
using System.Text.Json;
using GeekStore.ProductApi.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GeekStore.ProductApi.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    protected readonly AppDbContext DbContext;
    protected readonly HttpClient ProductApiClient;

    protected BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        
        DbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();

        ProductApiClient = factory.CreateClient();
    }

    protected async Task<(HttpStatusCode, TResponseContent?)> PostAsync<TRequestContent, TResponseContent>(string url, TRequestContent requestContent)
    {
        var jsonBody = JsonSerializer.Serialize(requestContent);
        var httpContent = new StringContent(jsonBody);
        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        var response = await ProductApiClient.PostAsync(url, httpContent);
        
        TResponseContent? responseContent = JsonSerializer.Deserialize<TResponseContent>(await response.Content.ReadAsStringAsync());
        
        return (response.StatusCode, responseContent);
    }
}