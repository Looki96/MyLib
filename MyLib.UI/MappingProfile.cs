using AutoMapper;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, UpdateBookDto>();
            CreateMap<BookDto, CreateBookDto>();
            CreateMap<UserDto, UpdateUserDto>();
            CreateMap<UserDto, CreateUserDto>();
        }
    }
}
