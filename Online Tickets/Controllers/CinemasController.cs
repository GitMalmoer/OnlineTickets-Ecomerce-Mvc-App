using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Tickets.Data;
using Online_Tickets.Data.Services;
using Online_Tickets.Models;

namespace Online_Tickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _service.GetById(id);
            if (cinema == null) return View("NotFound");

            return View(cinema);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _service.AddAsync(cinema);
            return RedirectToAction("Index", "Cinemas");
        }
    }
}
