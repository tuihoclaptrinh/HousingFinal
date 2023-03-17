using housing_back_end.Data;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetCities()
    {
        var cities = context.Cities.ToList();
        return Ok(cities);
    }
}