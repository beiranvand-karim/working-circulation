using Microsoft.AspNetCore.Mvc;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SilvermanPillTakingController(
        ISilvermanPillTakingRepository silvermanPillTakingRepository,
        IConfiguration configuration) : ControllerBase
    {
        private int DefaultPageSize =>
            configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpPost]
        public async Task<IActionResult> AddSilvermanPillTaking([FromBody] SilvermanPillTaking silvermanPillTaking)
        {
            var addedSilvermanPillTaking = await silvermanPillTakingRepository.AddSilvermanPillTakingAsync(silvermanPillTaking);
            return CreatedAtAction(nameof(GetSilvermanPillTakingById), new { id = addedSilvermanPillTaking.Id }, addedSilvermanPillTaking);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSilvermanPillTakings(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var result = await silvermanPillTakingRepository.GetAllSilvermanPillTakingsPagedAsync(
                pageNumber,
                pageSize ?? DefaultPageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSilvermanPillTakingById(int id)
        {
            var silvermanPillTaking = await silvermanPillTakingRepository.GetSilvermanPillTakingByIdAsync(id);
            if (silvermanPillTaking == null)
            {
                return NotFound();
            }
            return Ok(silvermanPillTaking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSilvermanPillTaking(int id, [FromBody] SilvermanPillTaking silvermanPillTaking)
        {
            if (id != silvermanPillTaking.Id)
            {
                return BadRequest();
            }
            var updatedSilvermanPillTaking = await silvermanPillTakingRepository.UpdateSilvermanPillTakingAsync(silvermanPillTaking);
            return Ok(updatedSilvermanPillTaking);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSilvermanPillTaking(int id)
        {
            await silvermanPillTakingRepository.DeleteSilvermanPillTakingAsync(id);
            return NoContent();
        }

    }
}