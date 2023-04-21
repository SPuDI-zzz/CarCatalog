namespace CarCatalog.Services.CarFilter;

using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;


public class CarFilterService : ICarFilterService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;

    public CarFilterService(
        IDbContextFactory<MainDbContext> contextFactory
        )
    {
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<CarFilterModel>> Index(GetCarsFilterModel model)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var cars = from carMark in context.CarMarks
                   join carModel in context.CarModels
                   on carMark.Id equals carModel.IdCarMark
                   join carGeneration in context.CarGenerations
                   on carModel.Id equals carGeneration.IDCarModel
                   join carConfiguration in context.CarConfigurations
                   on carGeneration.Id equals carConfiguration.IdCarGeneration
                   join carBodyType in context.CarBodyTypes
                   on carConfiguration.IdCarBodyType equals carBodyType.Id
                   join carDriveType in context.CarDriveTypes
                   on carConfiguration.IdCarDriveType equals carDriveType.Id
                   join carEngineType in context.CarEngineTypes
                   on carConfiguration.IdCarEgineType equals carEngineType.Id
                   join carTransmission in context.CarTransmissions
                   on carConfiguration.IdCarTransmission equals carTransmission.Id
                   join carForSale in context.CarsForSale
                   on carConfiguration.Id equals carForSale.IdCarConfiguration
                   select new
                   {
                       carMark, carModel, carGeneration ,carBodyType, carDriveType, carEngineType, carTransmission, carForSale
                   };

        if (model.CarMarkUid != null)
        {
            cars = from car in cars
                   where car.carMark.Uid == model.CarMarkUid
                   select car;
        }

        if (model.CarModelUid != null)
        {
            cars = from car in cars
                   where car.carModel.Uid == model.CarModelUid
                   select car;
        }

        if (model.CarGenerationUid != null)
        {
            cars = from car in cars
                   where car.carGeneration.Uid == model.CarGenerationUid
                   select car;
        }

        if (model.CarBodyTypeId != null)
        {
            cars = from car in cars
                   where car.carBodyType.Id == model.CarBodyTypeId
                   select car;
        }

        if (model.CarDriveTypeId != null)
        {
            cars = from car in cars
                   where car.carDriveType.Id == model.CarDriveTypeId
                   select car;
        }

        if (model.CarEngineTypeId != null)
        {
            cars = from car in cars
                   where car.carEngineType.Id == model.CarEngineTypeId
                   select car;
        }

        if (model.CarTransmissionTypeId != null)
        {
            cars = from car in cars
                   where car.carTransmission.Id == model.CarTransmissionTypeId
                   select car;
        }

        if (model.CarPrice != null)
        {
            cars = from car in cars
                   where car.carForSale.Price >= model.CarPrice
                   select car;
        }

        var data = (await cars.ToListAsync())
            .Select(s => new CarFilterModel 
            { 
                CarMarkName = s.carMark.Name,
                CarModelName = s.carModel.Name,
                CarGenerationName = s.carGeneration.Name,
                CarBodyTypeName = s.carBodyType.Name,
                CarDriveTypeName = s.carDriveType.Name,
                CarEngineTypeName = s.carEngineType.Name,
                CarTransmissionName = s.carTransmission.Name,
                CarPrice = s.carForSale.Price
            })
            ;

        return data;            
    }
}
