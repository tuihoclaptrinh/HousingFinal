using housing_back_end.Data.Repo;
using housing_back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

[Route("api/{controller}")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityRepository _repo;
    
    public CityController(ICityRepository repo)
    {
        this._repo = repo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cities = await _repo.GetCitiesAsync();
        return Ok(cities);
    }
    
    // Post api/city/add?cityName=Name
    // Post api/city/add/Name
    /*[HttpPost("add")]
    [HttpPost("add/{cityName}")]
    public async Task<IActionResult> AddCity(string cityName)
    {
        City city = new City();
        city.Name = cityName;
        await _context.Cities.AddAsync(city);
        await _context.SaveChangesAsync();
        return Ok(city);
    }*/
    
    // Post api/city/post -- Post the data JSON format
    [HttpPost("post")]
    public async Task<IActionResult> AddCity(City city)
    {
        _repo.AddCity(city);
        await _repo.SaveAsync();
        return StatusCode(201);
    }
    
    [HttpDelete("delete/{cityId}")]
    public async Task<IActionResult> DeleteCity(int cityId)
    {
        _repo.DeteleCity(cityId);
        await _repo.SaveAsync();
        return Ok(cityId);
    }
    
}