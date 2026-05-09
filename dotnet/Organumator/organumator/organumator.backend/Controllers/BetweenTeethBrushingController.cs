using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetweenTeethBrushingController(IBetweenTeethBrushingRepository betweenTeethBrushingRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBetweenTeethBrushing()
        {
            var betweenTeethBrushing = await betweenTeethBrushingRepository.GetAllBetweenTeethBrushingAsync();
            return Ok(betweenTeethBrushing);
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