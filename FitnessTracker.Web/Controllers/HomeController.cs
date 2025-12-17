using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Manager"))
                {
                    return RedirectToAction(
                        "Index",
                        "Exercise",
                        new { area = "Admin" }
                    );
                }

                return RedirectToAction(
                    "Index",
                    "Training",
                    new { area = "User" }
                );
            }

            return View();
        }
    }
}
