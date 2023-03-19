using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Data.Repo;

public class FurnishingTypeRepository : IFurnishingTypeRepository
{
    private readonly DataContext dc;

    public FurnishingTypeRepository(DataContext dc)
    {
        this.dc = dc;
    }
    public async Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync()
    {
        return await dc.FurnishingTypes.ToListAsync();
    }
}