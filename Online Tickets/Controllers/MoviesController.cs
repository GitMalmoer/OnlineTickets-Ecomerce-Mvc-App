using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Online_Tickets.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Tickets.Data.Services;

namespace Online_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
    }
}
