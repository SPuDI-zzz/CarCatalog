namespace CarCatalog.Context.Entities;
public class CarConfiguration : BaseEntity
{
    public string NameSeria { get; set; }

    public int Trunk { get; set; }

    public int HorsePower { get; set; }

    public float EngineCapasity { get; set; }

    public string WheelType { get; set; }

    public int? IdCarDriveType { get; set; }
    public CarDriveType CarDriveType { get; set; }

    public int? IdCarBodyType { get; set; }
    public CarBodyType CarBodyType { get; set; }

    public int? IdCarEgineType { get; set; }
    public CarEgineType CarEgineType { get; set; }

    public int? IdCarTransmission { get; set; }
    public CarTransmission CarTransmission { get; set; }

    public int? IdCarGeneration { get; set; }
    public CarGeneration CarGeneration { get; set; }

    public ICollection<CarForSale> CarForSales { get; set; }
}

