namespace CarCatalog.Context.Entities;

public class CarBodyType : BaseEntity
{
    public string Name { get; set; }

    public int? IdCarConfiguration { get; set; }
    public CarConfiguration CarConfiguration { get; set; }
}

