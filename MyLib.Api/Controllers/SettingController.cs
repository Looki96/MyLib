using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/setting")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingDto>>> GetAll()
        {
            var result = await _settingService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SettingDto>> GetById([FromRoute] int id)
        {
            var result = await _settingService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetByKey/{key}")]
        public async Task<ActionResult<SettingDto>> GetByKey([FromRoute] string key)
        {
            var result = await _settingService.GetByKey(key);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] string value)
        {
            var result = await _settingService.Update(id, value);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
