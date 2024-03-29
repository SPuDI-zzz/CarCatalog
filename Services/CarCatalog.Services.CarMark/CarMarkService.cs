﻿namespace CarCatalog.Services.CarMark;

using AutoMapper;
using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Validator;
using CarCatalog.Context;
using CarCatalog.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class CarMarkService : ICarMarkService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<GetCarMarksModel> getCarMarksModelValidator;
    private readonly IModelValidator<AddCarMarkModel> addCarMarkModelValidator;
    private readonly IModelValidator<UpdateCarMarkModel> updateCarMarkModelValidator;

    public CarMarkService(
        IDbContextFactory<MainDbContext> contextFactory
        , IMapper mapper
        , IModelValidator<GetCarMarksModel> getCarMarksModelValidator
        , IModelValidator<AddCarMarkModel> addCarMarkModelValidator
        , IModelValidator<UpdateCarMarkModel> updateCarMarkModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.getCarMarksModelValidator = getCarMarksModelValidator;
        this.addCarMarkModelValidator = addCarMarkModelValidator;
        this.updateCarMarkModelValidator = updateCarMarkModelValidator;
    }

    public async Task<IEnumerable<CarMarkModel>> GetCarMarks(GetCarMarksModel model)
    {
        getCarMarksModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carMarks = context
            .CarMarks
            .Include(x => x.Country)
            .OrderBy(x => x.Name)
            .AsQueryable()
            ;

        carMarks = carMarks
            .Skip(model.Offset)
            .Take(model.Limit)
            ;

        var data = (await carMarks.ToListAsync())
            .Select(mapper.Map<CarMarkModel>)
            ;

        return data;
    }

    public async Task<CarMarkModel> GetCarMark(int carMarkId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carMark = await context
            .CarMarks
            .Include(x => x.Country)
            .FirstOrDefaultAsync(x => x.Id.Equals(carMarkId))
            ;

        var data = mapper.Map<CarMarkModel>(carMark);

        return data;
    }

    public async Task<CarMarkModel> AddCarMark(AddCarMarkModel model)
    {
        addCarMarkModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carMark = mapper.Map<CarMark>(model);
        await context.AddAsync(carMark);
        context.SaveChanges();

        return mapper.Map<CarMarkModel>(carMark);
    }

    public async Task UpdateCarMark(int carMarkId, UpdateCarMarkModel model)
    {
        updateCarMarkModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var carMark = await context.CarMarks.FirstOrDefaultAsync(x => x.Id.Equals(carMarkId))
            ?? throw new ProcessException($"The car mark (id : {carMarkId}) was not found");

        carMark = mapper.Map(model, carMark);

        context.CarMarks.Update(carMark);
        context.SaveChanges();
    }

    public async Task DeleteCarMark(int carMarkId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var carMark = await context.CarMarks.FirstOrDefaultAsync(x => x.Id.Equals(carMarkId))
            ?? throw new ProcessException($"The car mark (id : {carMarkId}) was not found");

        context.Remove(carMark);
        context.SaveChanges();
    }
}
