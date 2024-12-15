using OnlineShop.Domain.Entities.Base;
using OnlineShop.Domain.Entities.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities.Orders;

public class Order: BaseEntity<int>
{
    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public DateTime CDT { get; set; }
    
    [MaxLength(20)]
    public string ShippingType { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal? DiscountPercentage { get; set; } 
    public decimal? DiscountPrice { get; set; }
    public Customer Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
