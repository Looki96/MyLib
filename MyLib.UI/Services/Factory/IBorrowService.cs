using MyLib.DataModels.Models.Dtos;

namespace MyLib.UI.Services.Factory
{
    public interface IBorrowService
    {
        Task<HttpResponseMessage> Create(CreateBorrowDto borrow);
        Task Delete(int id);
        Task<IEnumerable<BorrowDto>> GetAll();
        Task<BorrowDto> GetById(int id);
        Task<IEnumerable<BorrowDto>> GetOwn();
        Task GiveBack(int id);
    }
}