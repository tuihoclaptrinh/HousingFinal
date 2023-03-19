using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data.Repo;

public class PropertyTypeRepository : IPropertyTypeRepository
{
    private readonly DataContext dc;

    public PropertyTypeRepository(DataContext dc)
    {
        this.dc = dc;
    }
    public async Task<IEnumerable<PropertyType>> GetPropertyTypesAsync()
    {
        return await dc.PropertyTypes.ToListAsync();
    }
}