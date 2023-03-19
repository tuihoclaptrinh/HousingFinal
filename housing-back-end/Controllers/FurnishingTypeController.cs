using AutoMapper;
using housing_back_end.Dtos;
using housing_back_end.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

public class FurnishingTypeController: BaseController
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public FurnishingTypeController(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    // GET api/furnishingtypes
    [HttpGet("list")]        
    [AllowAnonymous]
    public async Task<IActionResult> GetFurnishingTypes()
    {            
        var furnishingTypes = await uow.FurnishingTypeRepository.GetFurnishingTypesAsync();
        var furnishingTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(furnishingTypes);
        return Ok(furnishingTypesDto);
    }

}