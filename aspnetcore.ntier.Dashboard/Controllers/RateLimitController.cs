using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class RateLimitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
