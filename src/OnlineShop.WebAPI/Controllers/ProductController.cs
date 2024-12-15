using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.WebAPI.Controllers.Base;

namespace OnlineShop.WebAPI.Controllers;

public class ProductController : BaseApiController
{
    private IProductService _ProductService;

    public ProductController(IProductService productService)
    {
        _ProductService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductDto productDto)
    {
        var productId = await _ProductService.CreateProduct(productDto);
        return Ok(productId);
    }
}
