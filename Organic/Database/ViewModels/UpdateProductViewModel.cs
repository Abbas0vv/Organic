using System.ComponentModel.DataAnnotations;

namespace Organic.Database.ViewModels;

public class UpdateProductViewModel
{
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    public decimal NormalPrice { get; set; }
    public decimal? Offer { get; set; }
    public IFormFile? File { get; set; }
}
