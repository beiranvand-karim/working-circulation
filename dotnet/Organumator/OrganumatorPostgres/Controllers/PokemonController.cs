using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using organumator.Models;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PokemonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getpokemons")]
        public async Task<IActionResult> GetPokemons()
        {
            var pokemons = await _context.Pokemons.Select(p => new Pokemon
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type
            }).ToListAsync();


            return Ok(pokemons);
        }

        [HttpPost("createpokemon")]
        public async Task<ActionResult<Pokemon>> CreatePokemon([FromBody] Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemons), new { id = pokemon.Id }, pokemon);
        }


        [HttpPut("editpokemon/{id}")]
        public async Task<ActionResult<Pokemon>> EditPokemon(int id, [FromBody] Pokemon updatedPokemon)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }


            pokemon.Name = updatedPokemon.Name;
            pokemon.Type = updatedPokemon.Type;

            await _context.SaveChangesAsync();

            return Ok(pokemon);
        }

        [HttpDelete("deletepokemon/{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
