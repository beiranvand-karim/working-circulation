using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaceHydrationController(IFaceHydrationRepository faceHydrationRepository) : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<FaceHydration>> Get()
        {
            return await faceHydrationRepository.GetAllFaceHydrationsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FaceHydration>> GetById(int id)
        {
            try
            {
                var faceHydration = await faceHydrationRepository.GetFaceHydrationByIdAsync(id);
                return faceHydration;

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FaceHydration>> Create(FaceHydration faceHydration)
        {
            var createdFaceHydration = await faceHydrationRepository.AddFaceHydrationAsync(faceHydration);
            return CreatedAtAction(nameof(GetById), new { id = createdFaceHydration.Id }, createdFaceHydration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FaceHydration>> Update(int id, FaceHydration faceHydration)
        {
            if (id != faceHydration.Id)
            {
                return BadRequest("Id in URL does not match Id in body.");
            }
            await faceHydrationRepository.UpdateFaceHydrationAsync(faceHydration);
            return Ok(faceHydration);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await faceHydrationRepository.DeleteFaceHydrationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}