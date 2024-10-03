using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public double Price { get; set; }
    public string Condition { get; set; } = string.Empty;
}
