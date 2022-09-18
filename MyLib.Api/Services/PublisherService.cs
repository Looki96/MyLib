using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Entities;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly MyLibContext _dbContext;
        private readonly IMapper _mapper;

        public PublisherService(MyLibContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublisherDto>> GetAll()
        {
            var publishers = await _dbContext.Publishers
                .ToListAsync();

            var result = _mapper.Map<List<PublisherDto>>(publishers);

            return result;
        }

        public async Task<PublisherDto> GetById(int id)
        {
            var publisher = await _dbContext.Publishers
                .FirstOrDefaultAsync(e => e.Id == id);

            var result = _mapper.Map<PublisherDto>(publisher);

            return result;
        }

        public async Task<int> Create(CreatePublisherDto dto)
        {
            var publisher = _mapper.Map<Publisher>(dto);
            _dbContext.Publishers.Add(publisher);
            await _dbContext.SaveChangesAsync();

            return publisher.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var publisher = await _dbContext.Publishers.FirstOrDefaultAsync(b => b.Id == id);

            if (publisher == null)
            {
                return false;
            }

            _dbContext.Publishers.Remove(publisher);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
