using OnlineShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Products;

public class Product: BaseEntity<int>
{
    [MaxLength(200)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsFragile { get; set; }
    public bool HasDiscount { get; set; }
    public decimal Profit { get; set; }
}
