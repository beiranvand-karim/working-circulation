using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using organumator.Messaging;
using organumator.Messaging.ClothesWearing;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothesWearingsController(IRabbitMqPublisher publisher, IOptions<RabbitMqSettings> settings) : ControllerBase
    {
        private readonly string Queue = settings.Value.ClothesWearingCommandQueueName;

        [HttpGet]
        public async Task<IEnumerable<ClothesWearing>> Get()
        {
            var result = await publisher.QueryAsync<List<ClothesWearing>>(
                new ClothesWearingCommand { Action = "GetAll" }, Queue);
            return result ?? [];
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
            var created = await publisher.QueryAsync<ClothesWearing>(
                new ClothesWearingCommand { Action = "Create", Payload = clothesWearing }, Queue);
            return CreatedAtAction(nameof(GetById), new { id = created!.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClothesWearing clothesWearing)
        {
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
