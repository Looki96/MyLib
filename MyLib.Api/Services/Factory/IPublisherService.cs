using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface IPublisherService
    {
        Task<int> Create(CreatePublisherDto dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<PublisherDto>> GetAll();
        Task<PublisherDto> GetById(int id);
    }
}