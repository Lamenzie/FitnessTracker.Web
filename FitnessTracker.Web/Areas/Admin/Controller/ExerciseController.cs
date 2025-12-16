using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize] // Základní ochrana celé Admin oblasti
    public class ExerciseController : Controller
    {
        private readonly IExerciseAppService _exerciseAppService;

        public ExerciseController(IExerciseAppService exerciseAppService)
        {
            _exerciseAppService = exerciseAppService;
        }

        // =========================
        // LIST (viditelný pro všechny přihlášené)
        // =========================
        public IActionResult Index()
        {
            var exercises = _exerciseAppService.Select();
            return View(exercises);
        }

        // =========================
        // CREATE – GET (formulář)
        // =========================
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREATE – POST (uložení)
        // =========================
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            _exerciseAppService.Create(exercise);
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // EDIT – GET
        // =========================
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(int id)
        {
            var exercise = _exerciseAppService.GetById(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // =========================
        // EDIT – POST
        // =========================
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            _exerciseAppService.Update(exercise);
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // DELETE
        // =========================
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Delete(int id)
        {
            _exerciseAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
