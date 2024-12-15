using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.Base;

namespace OnlineShop.Domain.Entities.Orders;

public class OrderItem: BaseEntity<int>
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [ForeignKey("OrderId")]
    public Order Order { get; set; }

    public int Quantity { get; set; }
}
