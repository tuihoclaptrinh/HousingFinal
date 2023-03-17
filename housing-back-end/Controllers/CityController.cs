using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

[Route("api/{controller}")]
[ApiController]
public class CityController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Atlanta", "New York" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "New York";
    }
}