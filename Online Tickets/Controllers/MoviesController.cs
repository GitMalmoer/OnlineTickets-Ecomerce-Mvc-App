using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Online_Tickets.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Online_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(m => m.Cinema).OrderBy(m => m.Name).ToListAsync();
            return View(allMovies);
        }
    }
}
