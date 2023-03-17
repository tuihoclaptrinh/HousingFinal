using AutoMapper;
using housing_back_end.Dtos;
using housing_back_end.Models;

namespace housing_back_end.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<City, CityDto>().ReverseMap();
    }
}