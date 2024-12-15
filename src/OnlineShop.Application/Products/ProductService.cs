using OnlineShop.Application.Base;
using OnlineShop.Application.Contracts;
using OnlineShop.Application.Contracts.Dtos;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructure.PersistenceBase;

namespace OnlineShop.Application.Products;

public class ProductService : BaseService, IProductService
{
    public ProductService(IPersisterlayers persisterlayers) : base(persisterlayers)
    {
    }

    public async Task<int> CreateProduct(ProductDto productDto)
    {
        Product product = new()
        {
            HasDiscount = productDto.HasDiscount,
            IsFragile = productDto.IsFragile,
            Name = productDto.Name,
            Price = productDto.Price,
            Profit = productDto.Profit
        };
        await _Persisterlayers.AddAsync(product);
        await _Persisterlayers.CommitAsync();
        return product.Id;
    }
}
