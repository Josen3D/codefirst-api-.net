using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        // agregamos el contexto de la BD.
        private Bar_dbContext _context;

        // creamos el constructor de la clase
        public BeerController(Bar_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Beer>> Get() =>  await _context.Beers.ToListAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeer(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer is null) return NotFound();

            return Ok(beer);
        }

        [HttpPost]
        public async Task<IActionResult> PostBeer(Beer beer)
        {
            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            return Created($"beer/{beer.BeerID}", beer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeer(int id, Beer beerRequest)
        {
            // find the beer
            var beer = await _context.Beers.FindAsync(id);

            if (beer is null) return NotFound();

            // update the item values.
            beer.Name = beerRequest.Name;
            beer.BrandID = beerRequest.BrandID;

            // save changes on DB
            await _context.SaveChangesAsync();

            return Ok(beer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        { 
            // find the beer to delete
            var beer = await _context.Beers.FindAsync(id);

            if (beer is null) return NotFound();

            // remove the item from DB.
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync(); // save changes on DB

            return NoContent();
        }
    }
}
