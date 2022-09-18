using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Entities;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;
using System.Linq;

namespace MyLib.Api.Services
{
    public class SettingService : ISettingService
    {
        private readonly MyLibContext _dbContext;
        private readonly IMapper _mapper;

        public SettingService(MyLibContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SettingDto>> GetAll()
        {
            var settings = await _dbContext.Settings
                .ToListAsync();

            var result = _mapper.Map<List<SettingDto>>(settings);

            return result;
        }

        public async Task<SettingDto> GetByKey(string key)
        {
            var setting = await _dbContext.Settings
                .FirstOrDefaultAsync(s => s.Key == key);

            var result = _mapper.Map<SettingDto>(setting);

            return result;
        }

        public async Task<SettingDto> GetById(int id)
        {
            var settings = await _dbContext.Settings
                .FirstOrDefaultAsync(b => b.Id == id);

            var result = _mapper.Map<SettingDto>(settings);

            return result;
        }

        public async Task<bool> Update(int id, string value)
        {
            var setting = await _dbContext.Settings.FirstOrDefaultAsync(s => s.Id == id);

            if (setting != null)
            {
                setting.Value = value;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
