using AutoMapper;
using housing_back_end.Dtos;
using housing_back_end.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

public class PropertyTypeController: BaseController
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    // GET api/propertytype/list
    [HttpGet ("list")]        
    [AllowAnonymous]
    public async Task<IActionResult> GetPropertyTypes()
    {            
        var PropertyTypes = await uow.PropertyTypeRepository.GetPropertyTypesAsync();
        var PropertyTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(PropertyTypes);
        return Ok(PropertyTypesDto);
    }

}