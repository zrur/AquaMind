using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracoesZonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConfiguracoesZonaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracaoZona>>> GetConfiguracaoZonas()
        {
            return await _context.ConfiguracaoZonas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracaoZona>> GetConfiguracaoZona(int id)
        {
            var item = await _context.ConfiguracaoZonas.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracaoZona(int id, ConfiguracaoZona item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracaoZonaExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ConfiguracaoZona>> PostConfiguracaoZona(ConfiguracaoZona item)
        {
            _context.ConfiguracaoZonas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetConfiguracaoZona", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracaoZona(int id)
        {
            var item = await _context.ConfiguracaoZonas.FindAsync(id);
            if (item == null) return NotFound();
            _context.ConfiguracaoZonas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ConfiguracaoZonaExists(int id)
        {
            return _context.ConfiguracaoZonas.Any(e => e.Id == id);
        }
    }
}
