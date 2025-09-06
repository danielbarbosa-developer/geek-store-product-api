using System.Net;
using FluentAssertions;
using GeekStore.ProductApi.Domain.Dtos;
using GeekStore.ProductApi.Domain.Dtos.Requests;

namespace GeekStore.ProductApi.IntegrationTests.ProductController;

public class ProductControllerIntegrationTest(IntegrationTestWebApplicationFactory factory)
    : BaseIntegrationTest(factory)
{
    private const string ControllerBasePath = "api/v1/products";

    [Fact]
    public async Task Should_Add_New_Product_With_Success_Http_Status_201()
    {
        // Arrange
        var expectedProductDto = new ProductDto();
        var addProductDto = new AddProductDto();

        // Act

        var (statusCode, actualProductDto) = await PostAsync<AddProductDto, ProductDto>(ControllerBasePath, addProductDto);

        // Assert
        statusCode.Should().Be(HttpStatusCode.Created);
        actualProductDto.Should().NotBeNull();
        actualProductDto.Should().BeEquivalentTo(expectedProductDto);
    }
}