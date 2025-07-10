using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class MockAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
