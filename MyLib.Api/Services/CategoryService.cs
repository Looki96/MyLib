using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Entities;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyLibContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(MyLibContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _dbContext.Categories
                .ToListAsync();

            var result = _mapper.Map<List<CategoryDto>>(categories);

            return result;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(b => b.Id == id);

            var result = _mapper.Map<CategoryDto>(category);

            return result;
        }

        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(b => b.Id == id);

            if (category == null)
            {
                return false;
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
