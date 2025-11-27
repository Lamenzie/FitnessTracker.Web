using FitnessTracker.Application.Interfaces;
using FitnessTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseAppService _exerciseService;

        public ExerciseController(IExerciseAppService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public IActionResult Index()
        {
            var list = _exerciseService.GetAllExercises();
            return View(list);
        }
    }
}
