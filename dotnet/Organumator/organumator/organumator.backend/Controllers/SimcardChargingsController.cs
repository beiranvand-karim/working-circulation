using Microsoft.AspNetCore.Mvc;
using organumator.Dtos;
using organumator.Interfaces;
using organumator.Mappers;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimcardChargingsController(
        ISimcardChargingRepository repository,
        IConfiguration configuration) : ControllerBase
    {
        private int DefaultPageSize => configuration.GetValue<int>("Pagination:DefaultPageSize");

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int? pageSize = null)
        {
            var paged = await repository.GetAllPagedAsync(pageNumber, pageSize ?? DefaultPageSize);
            var result = new PagedResult<SimcardChargingDto>
            {
                Items = paged.Items.Select(r => r.ToDto()).ToList(),
                TotalCount = paged.TotalCount,
                PageNumber = paged.PageNumber,
                PageSize = paged.PageSize
            };
            return Ok(result);
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
