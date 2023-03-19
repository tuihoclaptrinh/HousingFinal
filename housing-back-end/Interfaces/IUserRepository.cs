using housing_back_end.Models;

namespace housing_back_end.Interfaces;

public interface IUserRepository
{
    Task<User> Authenticate(string userName, string password);   
    void Register(string userName, string password);
    Task<bool> UserAlreadyExists(string userName);
}