using GeekStore.ProductApi.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.ProductApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<ProductDto> AddProduct()
    {
        return CreatedAtAction(nameof(AddProduct), new ProductDto()); 
    }
}