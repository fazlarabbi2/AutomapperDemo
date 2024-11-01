using AutoMapper;
using AutomapperDemo.Models;

namespace AutomapperDemo.Model;

public class MyMappingProfile : Profile
{
    public MyMappingProfile()
    {
        //Configure the mapping 
        CreateMap<Employee, EmployeeDTO>()
            .ForMember(d => d.EmployeeId, act => act.MapFrom(src => src.Id))
            //Address is a Complex type,
            //So, Map Address Object to Simple type using For Member and MapFrom Method
            .ForMember(dest => dest.City, act => act.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.State, act => act.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.Country, act => act.MapFrom(src => src.Address.Country))
            //Call the ReverseMap method to Make the Mapping Bi-Directional
            .ReverseMap();

        CreateMap<Category, CategoryDTO>();
    }
}