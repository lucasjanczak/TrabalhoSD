using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Image
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
}
