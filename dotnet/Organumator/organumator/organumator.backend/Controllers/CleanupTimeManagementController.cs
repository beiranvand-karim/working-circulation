using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;
using organumator.Mappers;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleanupTimeManagementController(ICleanupTimeManagementRepository repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await repository.GetAllAsync();
            return Ok(records.Select(r => r.ToDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await repository.GetByIdAsync(id);
            return Ok(record.ToDto());
        }

        [HttpPost("start")]
        public async Task<IActionResult> SaveStart()
        {
            var record = await repository.SaveStartAsync(DateTime.Now);
            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record.ToDto());
        }

        [HttpPost("{id}/finish")]
        public async Task<IActionResult> SaveFinish(int id)
        {
            var record = await repository.SaveFinishAsync(id, DateTime.Now);
            return Ok(record.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
