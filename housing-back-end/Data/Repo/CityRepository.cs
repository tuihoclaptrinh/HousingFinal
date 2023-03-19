using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data.Repo;

public class CityRepository: ICityRepository
{
    private readonly DataContext _context;

    public CityRepository(DataContext dc)
    {
        this._context = dc;
    }
    public void AddCity(City city)
    {
        _context.Cities.Add(city);             
    }

    public void DeleteCity(int CityId)
    {
        var city = _context.Cities.Find(CityId);
        _context.Cities.Remove(city);
    }

    public async Task<City> FindCity(int id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await _context.Cities.ToListAsync();
    }
}
