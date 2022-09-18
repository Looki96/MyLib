using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Entities;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById([FromRoute] int id)
        {
            var result = await _bookService.GetById(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Create([FromBody] CreateBookDto dto)
        {
            var id = await _bookService.Create(dto);
            return Created($"api/book/{id}", null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
            var result = await _bookService.Update(id, dto);
            
            if(!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _bookService.Delete(id);

            if(!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
