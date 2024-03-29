﻿namespace CarCatalog.Services.CarDriveType;

using AutoMapper;
using CarCatalog.Context.Entities;

public class CarDriveTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CarDriveTypeModelProfile : Profile
{
    public CarDriveTypeModelProfile()
    {
        CreateMap<CarDriveType, CarDriveTypeModel>();
    }
}
