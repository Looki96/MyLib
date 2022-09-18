using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Services.Factory
{
    public interface IBorrowService
    {
        Task<int> Create(CreateBorrowDto dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<BorrowDto>> GetAll();
        Task<BorrowDto> GetById(int id);
        Task<IEnumerable<BorrowDto>> GetOwn();
        Task<bool> GiveBack(int id);
    }
}