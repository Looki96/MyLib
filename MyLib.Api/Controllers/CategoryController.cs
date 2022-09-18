using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/category")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowDto>>> GetAll()
        {
            var result = await _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowDto>> GetById([FromRoute] int id)
        {
            var result = await _categoryService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var id = await _categoryService.Create(dto);
            return Created($"api/category/{id}", null);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _categoryService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
