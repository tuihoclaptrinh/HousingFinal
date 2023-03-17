using housing_back_end.Data;
using housing_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace housing_back_end.Controllers;

[Route("api/{controller}")]
[ApiController]
public class CityController : ControllerBase
{

    private readonly DataContext context;
    
    public CityController(DataContext context)
    {
        this.context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cities = await context.Cities.ToListAsync();
        return Ok(cities);
    }
    
    // Post api/city/add?cityName=Name
    // Post api/city/add/Name
    [HttpPost("add")]
    [HttpPost("add/{cityName}")]
    public async Task<IActionResult> AddCity(string cityName)
    {
        City city = new City();
        city.Name = cityName;
        await context.Cities.AddAsync(city);
        await context.SaveChangesAsync();
        return Ok(city);
    }
    
    // Post api/city/post -- Post the data JSON format
    [HttpPost("post")]
    public async Task<IActionResult> AddCity(City city)
    {
        await context.Cities.AddAsync(city);
        await context.SaveChangesAsync();
        return Ok(city);
    }
    
    [HttpDelete("delete/{cityId}")]
    public async Task<IActionResult> DeleteCity(int cityId)
    {
        var city = await context.Cities.FindAsync(cityId);
        context.Cities.Remove(city);
        await context.SaveChangesAsync();
        return Ok(city);
    }
    
}