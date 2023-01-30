using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Tickets.Data;
using Online_Tickets.Data.Services;
using Online_Tickets.Data.Static;
using Online_Tickets.Models;

namespace Online_Tickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;


        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _producersService.GetAllAsync();
            return View(allProducers);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _producersService.GetById(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producersService.GetById(id);
            if (producer == null) return View("NotFound");

            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
            await _producersService.UpdateAsync(id, producer);
            return RedirectToAction("Index", "Producers");
            }

            return View(producer);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _producersService.AddAsync(producer);
            return RedirectToAction("Index", "Producers");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _producersService.GetById(id);
            if (producer == null) return View("NotFound");

            return View(producer);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var producer = await _producersService.GetById(id);
            if (producer == null) return View("NotFound");

            await _producersService.DeleteAsync(id);
            return RedirectToAction("Index", "Producers");
        }



    }
}
