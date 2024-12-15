using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Contracts.Dtos;

public class CustomerDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
}
