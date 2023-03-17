using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data.Repo;

public class CityRepository: ICityRepository
{
    private readonly DataContext _context;

    public CityRepository(DataContext context)
    {
        this._context = context;
    }
    
    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public void AddCity(City city)
    {
        _context.Cities.AddAsync(city);
    }

    public void DeteleCity(int cityId)
    {
        var city = _context.Cities.Find(cityId);
        _context.Cities.Remove(city);
    }

    public async Task<City> FindCity(int id)
    {
        return await _context.Cities.FindAsync(id);
    }
}