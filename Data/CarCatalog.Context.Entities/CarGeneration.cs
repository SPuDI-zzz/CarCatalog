namespace CarCatalog.Context.Entities;

public class CarGeneration : BaseEntity
{
    public string Name { get; set; }

    public int YearBegin { get; set; }

    public int YearEnd { get; set; }

    public int? IDCarModel { get; set; }
    public CarModel CarModel { get; set; }

    public ICollection<CarConfiguration> CarConfigurations { get; set; }
}
