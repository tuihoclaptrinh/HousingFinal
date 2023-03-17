namespace housing_back_end.Interfaces;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    Task<bool> SaveAsync();
    
}