using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ZipCode { get; set; } = string.Empty;
    public int? Number { get; set; }
    [Required]
    public string Street { get; set; } = string.Empty;
    [Required]
    public string Neighborhood { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;
    [Required]
    public string State { get; set; } = string.Empty;
}
