using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class TrainingController : Controller
    {
        private readonly ITrainingSessionAppService _trainingService;
        private readonly IExerciseAppService _exerciseService;

        public TrainingController(
            ITrainingSessionAppService trainingService,
            IExerciseAppService exerciseService)
        {
            _trainingService = trainingService;
            _exerciseService = exerciseService;
        }

        // =========================
        // LIST mých tréninků
        // =========================
        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var sessions = _trainingService.GetMySessions(userId);
            return View(sessions);
        }

        // =========================
        // CREATE – GET
        // =========================
        public IActionResult Create()
        {
            ViewBag.Exercises = _exerciseService.Select();
            return View();
        }

        // =========================
        // CREATE – POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TrainingSession session)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Exercises = _exerciseService.Select();
                return View(session);
            }

            session.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _trainingService.Create(session);

            return RedirectToAction(nameof(Index));
        }
    }
}
