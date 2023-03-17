using AutoMapper;
using housing_back_end.Dtos;
using housing_back_end.Interfaces;
using housing_back_end.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

[Route("api/{controller}")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CityController(IUnitOfWork uow, IMapper mapper)
    {
        this._uow = uow;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cities = await _uow.CityRepository.GetCitiesAsync();

        var citiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);

        /*var citiesDto = from c in cities
            select new CityDto()
            {
                Id = c.Id,
                Name = c.Name
            };*/

        return Ok(citiesDto);
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
    public async Task<IActionResult> AddCity(CityDto cityDto)
    {
        var city = _mapper.Map<City>(cityDto);
        city.LastUpdateBy = 1;
        city.LastUpdatedOn = DateTime.Now;

        /*var city = new City
        {
            Name = cityDto.Name,
            LastUpdateBy = 1,
            LastUpdatedOn = DateTime.Now
        };*/

        _uow.CityRepository.AddCity(city);
        await _uow.SaveAsync();
        return StatusCode(201);
    }

    // 
    [HttpPut("updateCityName/{id}")]
    public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
    {
        var cityFromDb = await _uow.CityRepository.FindCity(id);
        cityFromDb.LastUpdateBy = 1;
        cityFromDb.LastUpdatedOn = DateTime.Now;
        _mapper.Map(cityDto, cityFromDb);
        await _uow.SaveAsync();
        return StatusCode(200);
    }
    
    // 
    [HttpPatch("update/{id}")]
    public async Task<IActionResult> UpdateCity(int id, JsonPatchDocument<City> cityToPatch)
    {
        var cityFromDb = await _uow.CityRepository.FindCity(id);
        cityFromDb.LastUpdateBy = 1;
        cityFromDb.LastUpdatedOn = DateTime.Now;
        
        cityToPatch.ApplyTo(cityFromDb, ModelState);
        await _uow.SaveAsync();
        return StatusCode(200);
    }
    
    [HttpDelete("delete/{cityId}")]
    public async Task<IActionResult> DeleteCity(int cityId)
    {
        _uow.CityRepository.DeteleCity(cityId);
        await _uow.SaveAsync();
        return Ok(cityId);
    }
}