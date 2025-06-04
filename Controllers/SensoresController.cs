using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SensoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensores()
        {
            return await _context.Sensores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            var item = await _context.Sensores.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, Sensor item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor item)
        {
            _context.Sensores.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSensor", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var item = await _context.Sensores.FindAsync(id);
            if (item == null) return NotFound();
            _context.Sensores.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SensorExists(int id)
        {
            return _context.Sensores.Any(e => e.Id == id);
        }
    }
}
