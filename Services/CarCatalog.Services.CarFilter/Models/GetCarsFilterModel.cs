namespace CarCatalog.Services.CarFilter;

public class GetCarsFilterModel
{
    public Guid? CarMarkUid { get; set; }
    public Guid? CarModelUid { get; set; }
    public Guid? CarGenerationUid { get; set; }
    public int? CarBodyTypeId { get; set; }
    public int? CarDriveTypeId { get; set; }
    public int? CarEngineTypeId { get; set; }
    public int? CarTransmissionTypeId { get; set; }
    public int? CarPrice { get; set; }
}
