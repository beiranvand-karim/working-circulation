using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using organumator.Dtos;
using organumator.Messaging;
using organumator.Messaging.VacuumCleanings;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacuumCleaningsController(
        IRabbitMqPublisher publisher,
        IOptions<RabbitMqSettings> settings,
        IConfiguration configuration) : ControllerBase
    {
        private readonly string Queue = settings.Value.CommandQueueName;
        private int DefaultPageSize => configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpGet]
        public async Task<ActionResult<PagedResult<VacuumCleanings>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var result = await publisher.QueryAsync<PagedResult<VacuumCleanings>>(
                new VacuumCleaningsCommand
                {
                    Action = "GetAll",
                    PageNumber = pageNumber,
                    PageSize = pageSize ?? DefaultPageSize
                }, Queue);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacuumCleanings>> GetById(int id)
        {
            var result = await publisher.QueryAsync<VacuumCleanings>(
                new VacuumCleaningsCommand { Action = "GetById", Id = id }, Queue);
            return result is null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<ActionResult<VacuumCleanings>> Create(VacuumCleanings vacuumCleanings)
        {
            var created = await publisher.QueryAsync<VacuumCleanings>(
                new VacuumCleaningsCommand { Action = "Create", Payload = vacuumCleanings }, Queue);
            return CreatedAtAction(nameof(GetById), new { id = created!.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, VacuumCleanings vacuumCleanings)
        {
            if (id != vacuumCleanings.Id)
                return BadRequest("Id in URL does not match Id in body.");
            publisher.PublishCommand(new VacuumCleaningsCommand { Action = "Update", Payload = vacuumCleanings }, Queue);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            publisher.PublishCommand(new VacuumCleaningsCommand { Action = "Delete", Id = id }, Queue);
            return Accepted();
        }
    }
}