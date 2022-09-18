using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MyLib.Api.Authorization;
using MyLib.Api.Entities;
using MyLib.Api.Middleware;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;
using MyLib.UI.Validation;
using System.Linq;
using System.Text.Json;

namespace MyLib.Api.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly MyLibContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;

        public BorrowService(MyLibContext dbContext, IMapper mapper, IUserContextService userContextService, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
        }

        public async Task<IEnumerable<BorrowDto>> GetAll()
        {
            var borrows = await _dbContext.Borrows
                .Include(e => e.Book)
                .Include(e => e.Librarian)
                .Include(e => e.Borrower)
                .ToListAsync();

            var result = _mapper.Map<List<BorrowDto>>(borrows);

            return result;
        }

        public async Task<IEnumerable<BorrowDto>> GetOwn()
        {
            var borrows = await _dbContext.Borrows
                .Include(e => e.Book)
                .Include(e => e.Librarian)
                .Include(e => e.Borrower)
                .Where(e => e.BorrowerId == _userContextService.UserId)
                .ToListAsync();

            var result = _mapper.Map<List<BorrowDto>>(borrows);

            return result;
        }

        public async Task<BorrowDto> GetById(int id)
        {
            var borrow = await _dbContext.Borrows
                .Include(e => e.Book)
                .Include(e => e.Librarian)
                .Include(e => e.Borrower)
                .FirstOrDefaultAsync(e => e.Id == id);

            var result = _mapper.Map<BorrowDto>(borrow);

            return result;
        }

        public async Task<int> Create(CreateBorrowDto dto)
        {
            var borrow = _mapper.Map<Borrow>(dto);
            borrow.LibrarianId = _userContextService.UserId.Value;
            borrow.CreateDate = DateTime.Now.Date;

            var book = await _dbContext.Books.FirstAsync(b => b.Id == borrow.BookId);
            var countBookBorrows = _dbContext.Borrows.Where(b => b.BookId == book.Id).Select(b => b.Id).Count();

            if (book.Quantity - countBookBorrows < 1)
            {
                var details = ServerValidationHelper.ServerValidationBadReqest();
                details.Errors = new Dictionary<string, string[]> { { "Book", new string[] { "No book in stock" } } };
                throw new BadRequestException(JsonSerializer.Serialize(details));
            }
            else if (_dbContext.Borrows.Any(b => b.BookId == dto.BookId && b.BorrowerId == dto.BorrowerId))
            {
                var details = ServerValidationHelper.ServerValidationBadReqest();
                details.Errors = new Dictionary<string, string[]> { { "Borrower", new string[] { "This user already borrowed this book" } } };
                throw new BadRequestException(JsonSerializer.Serialize(details));
            }

            _dbContext.Borrows.Add(borrow);
            await _dbContext.SaveChangesAsync();

            return borrow.Id;
        }

        public async Task<bool> GiveBack(int id)
        {
            var borror = await _dbContext.Borrows.FirstOrDefaultAsync(b => b.Id == id && b.ReturnDate == null);

            if (borror == null)
            {
                return false;
            }

            borror.ReturnDate = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var borrow = await _dbContext.Borrows.FirstOrDefaultAsync(b => b.Id == id);

            if (borrow == null)
            {
                return false;
            }

            _dbContext.Borrows.Remove(borrow);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
