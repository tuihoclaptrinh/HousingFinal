using housing_back_end.Models;

namespace housing_back_end.Interfaces;

public interface IUserRepository
{
    Task<User> Authenticate(string username, string password);
}