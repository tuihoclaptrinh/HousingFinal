using housing_back_end.Models;

namespace housing_back_end.Interfaces;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetCitiesAsync();
    void AddCity(City city);
    void DeleteCity(int CityId);
    Task<City> FindCity(int id);

}