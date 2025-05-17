using aspnetcore.ntier.BLL;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.PDF;
using aspnetcore.ntier.Dashboard.Controllers.Base;
using aspnetcore.ntier.Dashboard.Models.DashboardUser;
using aspnetcore.ntier.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using SelectPdf;
using System.Diagnostics.Metrics;
using System.IO;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aspnetcore.ntier.Dashboard.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IWeightService _weightService;
        private readonly ISiteService _siteService;

        public ReportController(IWeightService weightService, ISiteService siteService)
        {
            _weightService = weightService;
            _siteService = siteService;
        }
        public async Task<IActionResult> ReportDetails(ReportDetailsRequestViewModel model)
        {
            if (model.SiteId == 0)
            {
                return RedirectToAction("index", "home");
            }

            var site = await _siteService.GetUserSiteAsync(User.Identity.Name, model.SiteId);
            var results = new ReportDetailsResponseViewModel();
            if (model.SearchDate.HasValue && model.ReportType.HasValue)
            {
                results.ReportData = await _weightService.GetWeightReportData(model.SiteId, model.SearchDate.Value, model.ReportType.Value, User.Identity.Name, model.SearchDateTo, model.TruckNumber, model.Product, model.Classfication);
            }

            results.SiteId = model.SiteId;
            results.SearchDate = model.SearchDate;
            results.SearchDateTo = model.SearchDateTo;
            results.ReportType = model.ReportType;
            results.Site = site;
            results.Product = model.Product;
            results.Classfication = model.Classfication;
            return View(results);
        }

        public async Task<IActionResult> DownloadReport(ReportDetailsRequestViewModel model)
        {

            try
            {
                var weightReport = await _weightService.GetWeightReportData(model.SiteId, model.SearchDate.Value, model.ReportType.Value, User.Identity.Name, model.SearchDateTo, model.TruckNumber);

                if (weightReport.ReportData?.Count() > 0)
                {
                    var site = await _siteService.GetUserSiteAsync(User.Identity.Name, model.SiteId);
                    var pdfDto = new PdfDto
                    {
                        ReportData = weightReport.ReportData,
                        TotalTrucks = weightReport.TotalTrucks,
                        TotalViolationTrucks = weightReport.TotalViolationTrucks,
                        TotalViolationWeight = weightReport.TotalViolationWeight,
                        TotlaViolationNumberMoreThan5 = weightReport.TotlaViolationNumberMoreThan5,
                        TotlaViolationPrice = weightReport.TotlaViolationPrice,
                        reportType = model.ReportType.Value,
                        SiteName = site.SiteName,
                        SiteTitle = site.SiteTitle
                    };
                    PDFService pDFService = new PDFService(pdfDto);

                    var reportPdf = pDFService.GeneratePdf();
                    return File(reportPdf, "application/octet-stream", model.ReportType.ToString() + ".pdf");
                }

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("index", "home");

        }
    }
}
