using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Entities;
using MyLib.Api.Middleware;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services
{
    public class UserService : IUserService
    {
        private readonly MyLibContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(MyLibContext dbContext, IUserContextService userContextService, IPasswordHasher<User> passwordHasher, IMapper mapper)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            List<User> users = new List<User>();

            if (_userContextService.User.IsInRole("Admin"))
            {
                users = await _dbContext.Users
                    .Include(u => u.Role)
                    .ToListAsync();
            }
            else if (_userContextService.User.IsInRole("Librarrian"))
            {
                users = await _dbContext.Users
                    .Where(u => u.Role.Name == "Borrower")
                    .Include(u => u.Role)
                    .ToListAsync();
            }

            var result = _mapper.Map<List<UserDto>>(users);

            return result;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (user == null) return null;

            if (_userContextService.User.IsInRole("Librarrian") && "Admin,Librarrian".Contains(user.Role.Name))
            {
                throw new ForbiddenException();
            }

            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task<int> Create(CreateUserDto dto, UserRoles userRole)
        {
            var user = _mapper.Map<User>(dto);

            switch (userRole)
            {
                case UserRoles.Admin:
                    user.RoleId = 1;
                    break;

                case UserRoles.Librarrian:
                    user.RoleId = 2;
                    break;

                case UserRoles.Borrower:
                    user.RoleId = 3;
                    break;
            }

            user.Active = true;
            user.ChangePassword = true;

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.Password = hashedPassword;

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> Update(int id, UpdateUserDto dto)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(b => b.Id == id);

            if (user == null)
            {
                return false;
            }

            user.Name = dto.Name;
            user.SName = dto.SName;
            user.EMail = dto.EMail;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(b => b.Id == id);

            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
