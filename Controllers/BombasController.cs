using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BombasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BombasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bomba>>> GetBombas()
        {
            return await _context.Bombas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bomba>> GetBomba(int id)
        {
            var item = await _context.Bombas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBomba(int id, Bomba item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BombaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Bomba>> PostBomba(Bomba item)
        {
            _context.Bombas.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBomba", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBomba(int id)
        {
            var item = await _context.Bombas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Bombas.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BombaExists(int id)
        {
            return _context.Bombas.Any(e => e.Id == id);
        }
    }
}
