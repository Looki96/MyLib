using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
        {
            var result = await _userService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("borrower")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> CreateBorrower([FromBody] CreateUserDto dto)
        {
            var id = await _userService.Create(dto, UserRoles.Borrower);
            return Created($"api/user/{id}", null);
        }

        [HttpPost("librarrian")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateLibrarrian([FromBody] CreateUserDto dto)
        {
            var id = await _userService.Create(dto, UserRoles.Librarrian);
            return Created($"api/user/{id}", null);
        }

        [HttpPost("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateAdmin([FromBody] CreateUserDto dto)
        {
            var id = await _userService.Create(dto, UserRoles.Librarrian);
            return Created($"api/user/{id}", null);
        }

        [HttpPut("borrower/{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> UpdateBorrower([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
            var result = await _userService.Update(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("librarrian/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateLibrarrian([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
            var result = await _userService.Update(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAdmin([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
            var result = await _userService.Update(id, dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("borrower/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteBorrower([FromRoute] int id)
        {
            var result = await _userService.Delete(id);

            if (!result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("librarrian/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteLibrarrian([FromRoute] int id)
        {
            var result = await _userService.Delete(id);

            if (!result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAdmin([FromRoute] int id)
        {
            var result = await _userService.Delete(id);

            if (!result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
