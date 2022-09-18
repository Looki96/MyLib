using AutoMapper;
using MyLib.Api.Entities;
using MyLib.DataModels.Models;
using MyLib.DataModels.Models.Dtos;
using System;

namespace MyLib.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Borrow, BorrowDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateBorrowDto, Borrow>();
            CreateMap<CreatePublisherDto, Publisher>();
            CreateMap<CreateUserDto, User>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Setting, SettingDto>();
            CreateMap<User, UserDto>()
                .ForMember(m => m.Role, c => c.MapFrom(s => (UserRoles)Enum.Parse(typeof(UserRoles), s.Role.Name)));
        }
    }
}
