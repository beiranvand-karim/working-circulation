using Microsoft.AspNetCore.Mvc;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivergolPillTakingController(
        ILivergolPillTakingRepository livergolPillTakingRepository,
        IConfiguration configuration) : ControllerBase
    {
        private int DefaultPageSize =>
            configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpPost]
        public async Task<IActionResult> AddLivergolPillTaking([FromBody] LivergolPillTakingModel livergolPillTaking)
        {
            var addedPillTaking = await livergolPillTakingRepository.AddLivergolPillTakingAsync(livergolPillTaking);
            return CreatedAtAction(nameof(GetLivergolPillTakingById), new { id = addedPillTaking.Id }, addedPillTaking);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLivergolPillTakings(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var result = await livergolPillTakingRepository.GetAllLivergolPillTakingsPagedAsync(
                pageNumber,
                pageSize ?? DefaultPageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLivergolPillTakingById(int id)
        {
            var pillTaking = await livergolPillTakingRepository.GetLivergolPillTakingByIdAsync(id);
            if (pillTaking == null)
            {
                return NotFound();
            }
            return Ok(pillTaking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLivergolPillTaking(int id, [FromBody] LivergolPillTakingModel livergolPillTaking)
        {
            var updatedPillTaking = await livergolPillTakingRepository.UpdateLivergolPillTakingAsync(livergolPillTaking);
            return Ok(updatedPillTaking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivergolPillTaking(int id)
        {
            await livergolPillTakingRepository.DeleteLivergolPillTakingAsync(id);
            return NoContent();
        }
    }
}