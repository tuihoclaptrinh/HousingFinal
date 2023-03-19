namespace housing_back_end.Interfaces;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    IUserRepository UserRepository { get; }
    Task<bool> SaveAsync();
    
}