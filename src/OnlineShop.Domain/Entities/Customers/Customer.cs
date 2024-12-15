using OnlineShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Customers;

public class Customer: BaseEntity<int>
{
    public DateTime CDT { get; set; }
    
    [MaxLength(200)]
    public string FirstName { get; set; }
    [MaxLength(200)]
    public string UserName { get; set; }
    [MaxLength(200)]
    public string LastName { get; set; }
}
