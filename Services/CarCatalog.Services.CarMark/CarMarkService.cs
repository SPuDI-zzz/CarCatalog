namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;

public class CarMarkService : ICarMarkService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CarMarkService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }
}
