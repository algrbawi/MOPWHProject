using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
