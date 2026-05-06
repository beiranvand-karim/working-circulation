using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AroundBrushingController(IAroundBrushingRepository _aroundBrushingRepository) : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<AroundBrushing>> Get()
        {
            return await _aroundBrushingRepository.GetAllAroundBrushingsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AroundBrushing>> GetById(int id)
        {
            try
            {
                var aroundBrushing = await _aroundBrushingRepository.GetAroundBrushingByIdAsync(id);
                return aroundBrushing;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AroundBrushing>> Create(AroundBrushing aroundBrushing)
        {
            var createdAroundBrushing = await _aroundBrushingRepository.AddAroundBrushingAsync(aroundBrushing);
            return CreatedAtAction(nameof(GetById), new { id = createdAroundBrushing.Id }, createdAroundBrushing);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AroundBrushing>> Update(int id, AroundBrushing aroundBrushing)
        {
            if (id != aroundBrushing.Id)
            {
                return BadRequest("Id in URL does not match Id in body.");

            }
            try
            {
                var updatedAroundBrushing = await _aroundBrushingRepository.UpdateAroundBrushingAsync(aroundBrushing);
                return updatedAroundBrushing;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aroundBrushingRepository.DeleteAroundBrushingAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}