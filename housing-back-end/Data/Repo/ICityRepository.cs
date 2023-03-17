using housing_back_end.Models;

namespace housing_back_end.Data.Repo;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetCitiesAsync();

    void AddCity(City city);

    void DeteleCity(int cityId);
    Task<bool> SaveAsync();

}