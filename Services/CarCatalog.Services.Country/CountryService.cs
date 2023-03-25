namespace CarCatalog.Services.Country;

using AutoMapper;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;


public class CountryService : ICountryService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public CountryService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper)
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<CountryModel>> GetCountries(int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var countries = context
            .Countries
            .AsQueryable()
            ;

        countries = countries
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 100)))
            ;

        var data = (await countries.ToListAsync())
            .Select(mapper.Map<CountryModel>)
            ;

        return data;
    }

    public async Task<CountryModel> GetCountry(int countryId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var country = await context
            .Countries
            .FirstOrDefaultAsync(x => x.Id.Equals(countryId))
            ;

        var data = mapper.Map<CountryModel>(country);

        return data;
    }
}
