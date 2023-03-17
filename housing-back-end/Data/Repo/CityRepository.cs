using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data.Repo;

public class CityRepository: ICityRepository
{
    private readonly DataContext context;

    public CityRepository(DataContext context)
    {
        this.context = context;
    }
    
    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await context.Cities.ToListAsync();
    }

    public void AddCity(City city)
    {
        context.Cities.AddAsync(city);
    }

    public void DeteleCity(int cityId)
    {
        var city = context.Cities.Find(cityId);
        context.Cities.Remove(city);
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}