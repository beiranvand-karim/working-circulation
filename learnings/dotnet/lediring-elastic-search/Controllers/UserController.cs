using lediring_elastic_search.Interfaces;
using lediring_elastic_search.Models;
using Microsoft.AspNetCore.Mvc;

namespace lediring_elastic_search.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IElasticSearchService<User> elasticService) : ControllerBase
{
    [HttpPost("create-index/{indexName}")]
    public async Task<IActionResult> CreateIndex(string indexName)
    {
        await elasticService.CreateIndexAsync(indexName);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        await elasticService.IndexAsync(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await elasticService.GetAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string query)
    {
        var results = await elasticService.SearchAsync(query);
        return Ok(results);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, User user)
    {
        await elasticService.UpdateAsync(id, user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await elasticService.DeleteAsync(id);
        return NoContent();
    }
}
