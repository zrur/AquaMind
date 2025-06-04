using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _context.Estados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            var item = await _context.Estados.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado item)
        {
            _context.Estados.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEstado", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var item = await _context.Estados.FindAsync(id);
            if (item == null) return NotFound();
            _context.Estados.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.Id == id);
        }
    }
}
