namespace CarCatalog.Context.Entities;

public class CarConfiguration : BaseEntity
{
    public int Trunk { get; set; }

    public int HorsePower { get; set; }

    public float EngineCapasity { get; set; }

    public bool LeftHandWheel { get; set; }

    public int? IdCarDriveType { get; set; }
    public virtual CarDriveType CarDriveType { get; set; }

    public int? IdCarBodyType { get; set; }
    public virtual CarBodyType CarBodyType { get; set; }

    public int? IdCarEgineType { get; set; }
    public virtual CarEngineType CarEgineType { get; set; }

    public int? IdCarTransmission { get; set; }
    public virtual CarTransmission CarTransmission { get; set; }

    public int? IdCarGeneration { get; set; }
    public virtual CarGeneration CarGeneration { get; set; }

    public virtual ICollection<CarForSale> CarForSales { get; set; }
}

