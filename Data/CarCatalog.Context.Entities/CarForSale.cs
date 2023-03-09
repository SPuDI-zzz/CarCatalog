namespace CarCatalog.Context.Entities;

using System.Data.SqlTypes;

public class CarForSale : BaseEntity
{
    public int Color { get; set; }

    public SqlMoney Price { get; set; }

    public int Mileage { get; set; }

    public int? IdCarConfiguration { get; set; }
    public CarConfiguration CarConfiguration { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<Comment> Comments { get; set; }
}
