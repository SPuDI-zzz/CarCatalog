namespace CarCatalog.Context.Entities;

public class CarForSale : BaseEntity
{
    public string Color { get; set; }

    public int Price { get; set; }

    public int Mileage { get; set; }

    public bool IsSold { get; set; }

    public int? IdCarConfiguration { get; set; }
    public virtual CarConfiguration CarConfiguration { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
}
