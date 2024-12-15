using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Contracts.Dtos;

public class OrderDto
{
    [Required]
    public int CustomerId { get; set; }
    public decimal? DiscountPercentage { get; set; }
    public decimal? DiscountPrice { get; set; }
    
    [Required]
    public OrderItemDto[]? Items { get; set; }
}
