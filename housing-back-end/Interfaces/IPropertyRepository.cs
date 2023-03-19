using housing_back_end.Models;

namespace housing_back_end.Interfaces;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent);
    Task<Property> GetPropertyDetailAsync(int id);
    Task<Property> GetPropertyByIdAsync(int id);
    void AddProperty(Property property);
    void DeleteProperty(int id);
}