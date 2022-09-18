using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Api.Services.Factory;
using MyLib.DataModels.Models.Dtos;

namespace MyLib.Api.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetAll()
        {
            var result = await _publisherService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherDto>> GetById([FromRoute] int id)
        {
            var result = await _publisherService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Create([FromBody] CreatePublisherDto dto)
        {
            var id = await _publisherService.Create(dto);
            return Created($"api/publisher/{id}", null);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Librarrian")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _publisherService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
