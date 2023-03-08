using Microsoft.AspNetCore.Mvc;

namespace DripChipProject.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
