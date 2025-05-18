namespace Organic.Database.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal NormalPrice { get; set; }
    public decimal? Offer { get; set; }
    public string? ImageUrl { get; set; }

    public decimal? DiscountedPrice
    {
        get
        {
            if (Offer.HasValue && Offer.Value > 0)
                return NormalPrice - ((NormalPrice * Offer.Value) / 100);
            else
                return null;
        }
    }
}
