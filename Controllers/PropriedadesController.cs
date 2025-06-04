using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropriedadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropriedadesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propriedade>>> GetPropriedades()
        {
            return await _context.Propriedades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Propriedade>> GetPropriedade(int id)
        {
            var item = await _context.Propriedades.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropriedade(int id, Propriedade item)
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
                if (!PropriedadeExists(id))
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
        public async Task<ActionResult<Propriedade>> PostPropriedade(Propriedade item)
        {
            _context.Propriedades.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropriedade", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropriedade(int id)
        {
            var item = await _context.Propriedades.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Propriedades.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropriedadeExists(int id)
        {
            return _context.Propriedades.Any(e => e.Id == id);
        }
    }
}
