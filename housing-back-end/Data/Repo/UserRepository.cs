using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data.Repo;

public class UserRepository : IUserRepository
{

    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        this._context = context;
    }
    
    public async Task<User> Authenticate(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }
}