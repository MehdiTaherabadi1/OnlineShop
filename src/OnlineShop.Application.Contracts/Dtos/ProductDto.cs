namespace OnlineShop.Application.Contracts.Dtos;

public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsFragile { get; set; }
    public bool HasDiscount { get; set; }
    public decimal Profit { get; set; }
}
