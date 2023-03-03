namespace CarCatalog.Context.Entities;

public class CarDriveType : BaseEntity
{
    public string Name { get; set; }

    public int? IdCarConfiguration { get; set; }
    public CarConfiguration CarConfiguration { get; set; }
}

