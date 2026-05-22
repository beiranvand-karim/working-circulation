using Microsoft.AspNetCore.Mvc;
using organumator.Messaging;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacuumCleaningsController(IRabbitMqPublisher publisher) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<VacuumCleanings>> Get()
        {
            var result = await publisher.QueryAsync<List<VacuumCleanings>>(
                new VacuumCleaningsCommand { Action = "GetAll" });
            return result ?? [];
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacuumCleanings>> GetById(int id)
        {
            var result = await publisher.QueryAsync<VacuumCleanings>(
                new VacuumCleaningsCommand { Action = "GetById", Id = id });
            return result is null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<ActionResult<VacuumCleanings>> Create(VacuumCleanings vacuumCleanings)
        {
            var created = await publisher.QueryAsync<VacuumCleanings>(
                new VacuumCleaningsCommand { Action = "Create", Payload = vacuumCleanings });
            return CreatedAtAction(nameof(GetById), new { id = created!.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, VacuumCleanings vacuumCleanings)
        {
            if (id != vacuumCleanings.Id)
                return BadRequest("Id in URL does not match Id in body.");
            publisher.PublishCommand(new VacuumCleaningsCommand { Action = "Update", Payload = vacuumCleanings });
            return Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            publisher.PublishCommand(new VacuumCleaningsCommand { Action = "Delete", Id = id });
            return Accepted();
        }
    }
}