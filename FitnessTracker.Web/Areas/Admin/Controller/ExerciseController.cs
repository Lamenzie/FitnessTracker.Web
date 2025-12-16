using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseAppService _exerciseAppService;

        public ExerciseController(IExerciseAppService exerciseAppService)
        {
            _exerciseAppService = exerciseAppService;
        }

        public IActionResult Index()
        {
            IList<Exercise> exercises = _exerciseAppService.Select();
            return View(exercises);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercise exercise) {
            if (!ModelState.IsValid) { 
                return View(exercise);    
            }

            _exerciseAppService.Create(exercise);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _exerciseAppService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Exercise exercise = _exerciseAppService.GetById(id);
            if (exercise == null)
                return NotFound();

            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exercise exercise)
        {
            if (!ModelState.IsValid)
                return View(exercise);

            _exerciseAppService.Update(exercise);
            return RedirectToAction(nameof(Index));
        }
    }
}
