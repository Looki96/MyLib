using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/borrow")]
    [ApiController]
    [Authorize]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult<IEnumerable<BorrowDto>>> GetAll()
        {
            var result = await _borrowService.GetAll();
            return Ok(result);
        }

        [HttpGet("my")]
        [Authorize(Roles = "Admin,Borrower")]
        public async Task<ActionResult<IEnumerable<BorrowDto>>> GetOwn()
        {
            var result = await _borrowService.GetOwn();

            if(result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult<BorrowDto>> GetById([FromRoute] int id)
        {
            var result = await _borrowService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Create([FromBody] CreateBorrowDto dto)
        {
            var id = await _borrowService.Create(dto);
            return Created($"api/borrow/{id}", null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> GiveBack([FromRoute] int id)
        {
            var result = await _borrowService.GiveBack(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _borrowService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
