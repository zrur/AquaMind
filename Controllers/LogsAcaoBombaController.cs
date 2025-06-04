using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsAcaoBombaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogsAcaoBombaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAcaoBomba>>> GetLogAcaoBombas()
        {
            return await _context.LogAcaoBombas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogAcaoBomba>> GetLogAcaoBomba(int id)
        {
            var item = await _context.LogAcaoBombas.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAcaoBomba(int id, LogAcaoBomba item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAcaoBombaExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<LogAcaoBomba>> PostLogAcaoBomba(LogAcaoBomba item)
        {
            _context.LogAcaoBombas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLogAcaoBomba", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAcaoBomba(int id)
        {
            var item = await _context.LogAcaoBombas.FindAsync(id);
            if (item == null) return NotFound();
            _context.LogAcaoBombas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool LogAcaoBombaExists(int id)
        {
            return _context.LogAcaoBombas.Any(e => e.Id == id);
        }
    }
}
