using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
