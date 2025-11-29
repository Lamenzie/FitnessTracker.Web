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
    }
}
