using Microsoft.AspNetCore.Mvc;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetweenTeethBrushingController(
        IBetweenTeethBrushingRepository betweenTeethBrushingRepository,
        IConfiguration configuration) : ControllerBase
    {
        private int DefaultPageSize =>
            configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpGet]
        public async Task<IActionResult> GetAllBetweenTeethBrushing(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var result = await betweenTeethBrushingRepository.GetAllBetweenTeethBrushingPagedAsync(
                pageNumber,
                pageSize ?? DefaultPageSize);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBetweenTeethBrushingById(int id)
        {
            var betweenTeethBrushing = await betweenTeethBrushingRepository.GetBetweenTeethBrushingByIdAsync(id);
            if (betweenTeethBrushing == null)
            {
                return NotFound();
            }
            return Ok(betweenTeethBrushing);
        }

        [HttpPost]
        public async Task<IActionResult> AddBetweenTeethBrushing(BetweenTeethBrushing betweenTeethBrushing)
        {
            await betweenTeethBrushingRepository.AddBetweenTeethBrushingAsync(betweenTeethBrushing);
            return CreatedAtAction(nameof(GetBetweenTeethBrushingById), new { id = betweenTeethBrushing.Id }, betweenTeethBrushing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBetweenTeethBrushing(int id, BetweenTeethBrushing betweenTeethBrushing)
        {
            if (id != betweenTeethBrushing.Id)
            {
                return BadRequest();
            }
            await betweenTeethBrushingRepository.UpdateBetweenTeethBrushingAsync(betweenTeethBrushing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBetweenTeethBrushing(int id)
        {
            await betweenTeethBrushingRepository.DeleteBetweenTeethBrushingAsync(id);
            return NoContent();
        }


    }
}