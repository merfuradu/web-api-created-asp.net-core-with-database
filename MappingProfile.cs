using AutoMapper;
using WebAPI_week1.DTOs;
using WebAPI_week1.Models;

namespace WebAPI_week1
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PersonalData, PersonalDataDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
