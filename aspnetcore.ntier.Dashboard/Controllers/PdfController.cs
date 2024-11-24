using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    [AllowAnonymous]
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(@"<h1>Mohammad Albitar</h1>");
            var file = doc.Save();
            doc.Close();

            return File(file, "application/pdf", "File.pdf");
        }
    }
}
