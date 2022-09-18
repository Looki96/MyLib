using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _accountService.Login(loginDto);
            return Ok(result);
        }
    }
}
