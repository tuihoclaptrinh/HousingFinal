using housing_back_end.Data.Repo;
using housing_back_end.Interfaces;

namespace housing_back_end.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        this._context = context;
    }

    public ICityRepository CityRepository => new CityRepository(_context);
    public IUserRepository UserRepository => new UserRepository(_context);

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}