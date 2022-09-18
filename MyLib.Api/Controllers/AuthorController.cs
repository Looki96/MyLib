using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/author")]
    [ApiController]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
        {
            var result = await _authorService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetById([FromRoute] int id)
        {
            var result = await _authorService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Create([FromBody] CreateAuthorDto dto)
        {
            var id = await _authorService.Create(dto);
            return Created($"api/author/{id}", null);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _authorService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
