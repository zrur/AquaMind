using Microsoft.AspNetCore.Mvc.RazorPages;
using AquaMind.API.Data;
using AquaMind.API.Models;

namespace AquaMind.API.Pages.Zonas
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Zona> Zonas { get; set; } = new List<Zona>();

        public async Task OnGetAsync()
        {
            Zonas = await _context.Zonas.ToListAsync();
        }
    }
}
