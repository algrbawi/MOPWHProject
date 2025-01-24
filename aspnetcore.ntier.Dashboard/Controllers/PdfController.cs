using aspnetcore.ntier.Dashboard.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class PdfController : BaseController
    {

        public IActionResult Index(int siteId)
        {
            return View();
        }

        public IActionResult GenerateReportAsHTML()
        {
            return View();
        }
    }
}
