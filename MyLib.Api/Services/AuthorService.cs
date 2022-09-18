using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Entities;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly MyLibContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorService(MyLibContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var authors = await _dbContext.Authors
                .ToListAsync();

            var result = _mapper.Map<List<AuthorDto>>(authors);

            return result;
        }

        public async Task<AuthorDto> GetById(int id)
        {
            var author = await _dbContext.Authors
                .FirstOrDefaultAsync(b => b.Id == id);

            var result = _mapper.Map<AuthorDto>(author);

            return result;
        }

        public async Task<int> Create(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();

            return author.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(b => b.Id == id);

            if (author == null)
            {
                return false;
            }

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
