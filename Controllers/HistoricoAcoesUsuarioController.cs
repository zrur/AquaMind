using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoAcoesUsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistoricoAcoesUsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoAcaoUsuario>>> GetHistoricoAcaoUsuarios()
        {
            return await _context.HistoricoAcaoUsuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoAcaoUsuario>> GetHistoricoAcaoUsuario(int id)
        {
            var item = await _context.HistoricoAcaoUsuarios.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoAcaoUsuario(int id, HistoricoAcaoUsuario item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoAcaoUsuarioExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<HistoricoAcaoUsuario>> PostHistoricoAcaoUsuario(HistoricoAcaoUsuario item)
        {
            _context.HistoricoAcaoUsuarios.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHistoricoAcaoUsuario", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoAcaoUsuario(int id)
        {
            var item = await _context.HistoricoAcaoUsuarios.FindAsync(id);
            if (item == null) return NotFound();
            _context.HistoricoAcaoUsuarios.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HistoricoAcaoUsuarioExists(int id)
        {
            return _context.HistoricoAcaoUsuarios.Any(e => e.Id == id);
        }
    }
}
