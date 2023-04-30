namespace CarCatalog.Web.Pages.CarsFilter;

public class GetCarsFilterModel
{
    public int? CarMarkId { get; set; }
    public int? CarModelId { get; set; }
    public int? CarGenerationId { get; set; }
    public int? CarBodyTypeId { get; set; }
    public int? CarDriveTypeId { get; set; }
    public int? CarEngineTypeId { get; set; }
    public int? CarTransmissionTypeId { get; set; }
    public int? CarPrice { get; set; }
    public int? Mileage { get; set; }
    public SortState SortOrder { get; set; }
}

public enum SortState
{
    NameAsc,
    NameDesc,
    PriceAsc,
    PriceDesc,
    MiliageAsc,
    MiliageDesc,
}
