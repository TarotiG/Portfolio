using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
