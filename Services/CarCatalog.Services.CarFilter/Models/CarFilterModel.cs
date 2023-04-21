namespace CarCatalog.Services.CarFilter;

using CarCatalog.Context.Entities;
using AutoMapper;

public class CarFilterModel
{
    public string CarMarkName { get; set; }
    public string CarModelName { get; set; }
    public string CarGenerationName { get; set; }
    public string CarBodyTypeName { get; set; }
    public string CarDriveTypeName { get; set; }
    public string CarEngineTypeName { get; set; }
    public string CarTransmissionName { get; set; }
    public int CarPrice { get; set; }
}

