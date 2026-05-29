using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;
using organumator.Mappers;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimcardChargingsController(ISimcardChargingRepository repository) : ControllerBase
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

        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var record = await repository.SaveAsync(DateTime.Now);
            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
