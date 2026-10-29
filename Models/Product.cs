using System.ComponentModel.DataAnnotations;

namespace CMS.Api;

public record Product(int Id, string Name, decimal Price);

public class ProductRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(typeof(decimal), "0.01", "1000000")]
    public decimal? Price { get; set; }
}