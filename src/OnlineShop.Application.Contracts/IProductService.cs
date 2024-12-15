using OnlineShop.Application.Contracts.Dtos;

namespace OnlineShop.Application.Contracts;

public interface IProductService
{
    Task<int> CreateProduct(ProductDto productDto);
}
