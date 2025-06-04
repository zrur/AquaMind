using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZonasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZonas()
        {
            return await _context.Zonas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetZona(int id)
        {
            var item = await _context.Zonas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutZona(int id, Zona item)
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
                if (!ZonaExists(id))
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
        public async Task<ActionResult<Zona>> PostZona(Zona item)
        {
            _context.Zonas.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZona", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(int id)
        {
            var item = await _context.Zonas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Zonas.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZonaExists(int id)
        {
            return _context.Zonas.Any(e => e.Id == id);
        }
    }
}
