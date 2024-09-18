using AutoMapper;
using MVCWebapp.DTOs.UserDTOs;
using MVCWebapp.DTOs.UserTypeDTOs;
using MVCWebapp.Models;

namespace MVCWebapp.Utilities
{
    public class MVCWebappProfile : Profile
    {
        public MVCWebappProfile()
        {
            //User Mapping
            CreateMap<User, UserReadDTO>();
            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<UserCreateDTO, User>();

            //UserType mapping
            CreateMap<UserType, UserTypeReadDTO>();
        }
    }
}
