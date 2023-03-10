namespace CarCatalog.Context.Entities;

using System.Data.SqlTypes;

public class CarForSale : BaseEntity
{
    public int Color { get; set; }
    
    public int Price { get; set; }

    public int Mileage { get; set; }

    public int? IdCarConfiguration { get; set; }
    public virtual CarConfiguration CarConfiguration { get; set; }

    public virtual ICollection<User> Users { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
}
