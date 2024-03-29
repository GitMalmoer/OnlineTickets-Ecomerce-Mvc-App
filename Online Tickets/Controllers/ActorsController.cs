﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Tickets.Data;
using Online_Tickets.Data.Services;
using Online_Tickets.Data.Static;
using Online_Tickets.Models;

namespace Online_Tickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _actorService.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorService.GetById(id);

            if (actor == null)
                return View("NotFound");

            return View(actor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Actor actor = await _actorService.GetById(id);

            if (actor == null)
                return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetById(id);

            if (actor == null)
                return View("NotFound");

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int Id)
        {
            var actor = await _actorService.GetById(Id);

            if (actor == null)
                return View("NotFound");

            await _actorService.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }

}
