using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosSensorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrosSensorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroSensor>>> GetRegistroSensors()
        {
            return await _context.RegistroSensors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroSensor>> GetRegistroSensor(int id)
        {
            var item = await _context.RegistroSensors.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroSensor(int id, RegistroSensor item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroSensorExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RegistroSensor>> PostRegistroSensor(RegistroSensor item)
        {
            _context.RegistroSensors.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRegistroSensor", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroSensor(int id)
        {
            var item = await _context.RegistroSensors.FindAsync(id);
            if (item == null) return NotFound();
            _context.RegistroSensors.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RegistroSensorExists(int id)
        {
            return _context.RegistroSensors.Any(e => e.Id == id);
        }
    }
}
