namespace CarCatalog.Services.CarModel;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarModelService : ICarModelService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarModelService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }
}
