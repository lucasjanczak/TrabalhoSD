using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Purchase
{
    [Key]
    public int Id { get; set; }
    [Required]
    public double Price { get; set; }
    public Person Buyer { get; set; } = new();
    [MinLength(1)]
    public List<Product> Products { get; set; } = [];
}
