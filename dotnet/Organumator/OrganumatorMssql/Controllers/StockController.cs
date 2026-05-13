using Microsoft.AspNetCore.Mvc;
using OrganumatorMssql.Data;
using OrganumatorMssql.Dtos.Stock;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Mappers;

namespace OrganumatorMssql.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDbContext applicationDbContext, IStockRepository stockRepository)
        {
            _applicationDbContext = applicationDbContext;
            _stockRepository = stockRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var stocks = await _stockRepository.GetAllAsync();
            return Ok(stocks.Select(s => s.ToStockDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var stock = stockDto.ToStock();
            await _stockRepository.CreateAsync(stock);
            return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var stock = await _stockRepository.UpdateAsync(id, updateStockDto);
            if (stock == null)
            {
                return NotFound();
            }

            await _applicationDbContext.SaveChangesAsync();
            return Ok(stock.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}