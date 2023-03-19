using housing_back_end.Models;

namespace housing_back_end.Interfaces;

public interface IFurnishingTypeRepository
{
    Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync();
}