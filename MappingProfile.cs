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
            CreateMap<WeatherDTO, Weather>().ReverseMap();
                //.ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName))
                //.ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.StateCode))
                //.ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                //.ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
                //.ForMember(dest => dest.Lon, opt => opt.MapFrom(src => src.Lon))
                //.ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.Timezone))
            CreateMap<DatumDTO, Datum>().ReverseMap();
        }
    }
}
