using Microsoft.AspNetCore.Mvc;
using organumator.Interfaces;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalciferolTakingController(
        ICalciferolTakingRepository repository,
        IConfiguration configuration) : ControllerBase
    {
        private int DefaultPageSize =>
            configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var result = await repository.GetAllPagedAsync(pageNumber, pageSize ?? DefaultPageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await repository.GetByIdAsync(id);
                return Ok(item);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.CalciferolTakingModel model)
        {
            await repository.AddAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Models.CalciferolTakingModel model)
        {
            if (id != model.Id)
                return BadRequest("ID mismatch");

            try
            {
                await repository.UpdateAsync(model);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}