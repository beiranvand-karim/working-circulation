using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacuumCleaningsController(IVacuumCleaningsRepository vacuumCleaningsRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<VacuumCleanings>> Get()
        {
            return await vacuumCleaningsRepository.GetAllVacuumCleaningsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacuumCleanings>> GetById(int id)
        {
            try
            {
                var vacuumCleanings = await vacuumCleaningsRepository.GetVacuumCleaningsByIdAsync(id);
                return vacuumCleanings;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<VacuumCleanings>> Create(VacuumCleanings vacuumCleanings)
        {
            var createdVacuumCleanings = await vacuumCleaningsRepository.AddVacuumCleaningsAsync(vacuumCleanings);
            return CreatedAtAction(nameof(GetById), new { id = createdVacuumCleanings.Id }, createdVacuumCleanings);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VacuumCleanings>> Update(int id, VacuumCleanings vacuumCleanings)
        {
            if (id != vacuumCleanings.Id)
            {
                return BadRequest("Id in URL does not match Id in body.");
            }
            await vacuumCleaningsRepository.UpdateVacuumCleaningsAsync(vacuumCleanings);
            return Ok(vacuumCleanings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await vacuumCleaningsRepository.DeleteVacuumCleaningsAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}