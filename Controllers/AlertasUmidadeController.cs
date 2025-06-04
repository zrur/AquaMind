using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasUmidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertasUmidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertaUmidade>>> GetAlertaUmidades()
        {
            return await _context.AlertaUmidades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlertaUmidade>> GetAlertaUmidade(int id)
        {
            var item = await _context.AlertaUmidades.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertaUmidade(int id, AlertaUmidade item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaUmidadeExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AlertaUmidade>> PostAlertaUmidade(AlertaUmidade item)
        {
            _context.AlertaUmidades.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAlertaUmidade", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertaUmidade(int id)
        {
            var item = await _context.AlertaUmidades.FindAsync(id);
            if (item == null) return NotFound();
            _context.AlertaUmidades.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AlertaUmidadeExists(int id)
        {
            return _context.AlertaUmidades.Any(e => e.Id == id);
        }
    }
}
