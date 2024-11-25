using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult GenerateReportAsHTML()
        {
            return View();
        }
    }
}
