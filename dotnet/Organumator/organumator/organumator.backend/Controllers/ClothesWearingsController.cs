using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using organumator.Dtos;
using organumator.Messaging;
using organumator.Messaging.ClothesWearing;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothesWearingsController(
        IRabbitMqPublisher publisher,
        IOptions<RabbitMqSettings> settings,
        IConfiguration configuration) : ControllerBase
    {
        private readonly string Queue = settings.Value.ClothesWearingCommandQueueName;
        private int DefaultPageSize => configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpGet]
        public async Task<ActionResult<PagedResult<ClothesWearing>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var result = await publisher.QueryAsync<PagedResult<ClothesWearing>>(
                new ClothesWearingCommand
                {
                    Action = "GetAll",
                    PageNumber = pageNumber,
                    PageSize = pageSize ?? DefaultPageSize
                }, Queue);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesWearing>> GetById(int id)
        {
            var result = await publisher.QueryAsync<ClothesWearing>(
                new ClothesWearingCommand { Action = "GetById", Id = id }, Queue);
            return result is null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<ActionResult<ClothesWearing>> Create(ClothesWearing clothesWearing)
        {
            ArgumentNullException.ThrowIfNull(clothesWearing);
            var created = await publisher.QueryAsync<ClothesWearing>(
                new ClothesWearingCommand { Action = "Create", Payload = clothesWearing }, Queue);
            ArgumentNullException.ThrowIfNull(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClothesWearing clothesWearing)
        {
            ArgumentNullException.ThrowIfNull(clothesWearing);
            if (id != clothesWearing.Id)
                return BadRequest("Id in URL does not match Id in body.");
            publisher.PublishCommand(new ClothesWearingCommand { Action = "Update", Payload = clothesWearing }, Queue);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            publisher.PublishCommand(new ClothesWearingCommand { Action = "Delete", Id = id }, Queue);
            return Accepted();
        }
    }
}
