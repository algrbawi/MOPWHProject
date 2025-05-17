using aspnetcore.ntier.DTO.DTOs;
using aspnetcore.ntier.DTO.Enum;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.PDF
{
    public class PDFService : IDocument
    {
        private readonly PdfDto pdfDto;
        public int CurrentPage { get; set; } = 1;
        public PDFService(PdfDto pdfDto)
        {
            this.pdfDto = pdfDto;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public void Compose(IDocumentContainer container)
        {

            container.Page(page =>
            {
                page.Margin(30);
                page.MarginRight(60);
                page.ContentFromRightToLeft();
                page.Size(PageSizes.A4);
                page.Header().Element(GetHeader);
                page.Content().Grid(grid =>
                {

                    grid.VerticalSpacing(15);
                    grid.HorizontalSpacing(15);
                    grid.AlignCenter();


                    grid.Item(12).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        table.Cell().Row(1).Column(1).Element(CellStyle).Height(30).AlignTop().Text("عدد الشاحنات").Bold().FontSize(15);
                        table.Cell().Row(1).Column(2).Element(CellStyle).Height(30).AlignTop().Text(pdfDto.TotalTrucks).Bold().FontSize(15);

                        table.Cell().Row(2).Column(1).Element(CellStyle).Height(30).AlignTop().Text("عدد الشاحنات المخالفة").Bold().FontSize(15);
                        table.Cell().Row(2).Column(2).Element(CellStyle).Height(30).AlignTop().Text(pdfDto.TotalViolationTrucks).Bold().FontSize(15);

                        table.Cell().Row(3).Column(1).Element(CellStyle).Height(30).AlignTop().Text("مجموع الاوزان المخالفة بالطن").Bold().FontSize(15);
                        table.Cell().Row(3).Column(2).Element(CellStyle).Height(30).AlignTop().Text(pdfDto.TotalViolationWeight).Bold().FontSize(15);

                        table.Cell().Row(4).Column(1).Element(CellStyle).Height(30).AlignTop().Text("قيمة المخالفات بالدينار").Bold().FontSize(15);
                        table.Cell().Row(4).Column(2).Element(CellStyle).Height(30).AlignTop().Text(pdfDto.TotlaViolationPrice).Bold().FontSize(15);

                        table.Cell().Row(5).Column(1).Element(CellStyle).Height(30).AlignTop().Text("مخالفات أكثر من 5 طن").Bold().FontSize(15);
                        table.Cell().Row(5).Column(2).Element(CellStyle).Height(30).AlignTop().Text(pdfDto.TotlaViolationNumberMoreThan5).Bold().FontSize(15);

                        // Add more rows as necessary
                    });

                });
                page.Footer().AlignCenter();
                //page.Footer().AlignCenter().Text("وزارة الأشغال العامة والإسكان - 2024");
            });

            container.Page(page =>
            {
                page.Margin(30);
                page.MarginRight(60);
                page.ContentFromRightToLeft();
                page.Size(PageSizes.A4.Landscape());
                page.Header().Element(GetHeader);
                page.Content().Grid(grid =>
                {

                    grid.VerticalSpacing(5);
                    grid.HorizontalSpacing(5);
                    grid.AlignCenter();
                    grid.Item(12).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            if (pdfDto.reportType == ReportType.daily || pdfDto.reportType == ReportType.vehicle)
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();

                            }
                            else if (pdfDto.reportType == ReportType.bill || pdfDto.reportType == ReportType.vehicle)
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            }
                            else
                            {

                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();

                            }

                        });
                        if (pdfDto.reportType == ReportType.daily || pdfDto.reportType == ReportType.vehicle)
                        {
                            table.Cell().Row(1).Column(1).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الرقم").Bold().FontSize(7);
                            table.Cell().Row(1).Column(2).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("رقم العملية").Bold().FontSize(7);
                            table.Cell().Row(1).Column(3).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("التاريخ").Bold().FontSize(7);
                            table.Cell().Row(1).Column(4).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الوقت").Bold().FontSize(7);
                            table.Cell().Row(1).Column(5).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("رقم المركبة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(6).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الجنسية").Bold().FontSize(7);
                            table.Cell().Row(1).Column(7).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("التصنيف").Bold().FontSize(7);
                            table.Cell().Row(1).Column(8).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("وزن المركبة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(9).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الوزن المسموح").Bold().FontSize(7);
                            table.Cell().Row(1).Column(10).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("فرق الوزن").Bold().FontSize(7);
                            table.Cell().Row(1).Column(11).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("المخالفة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(12).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الحمولة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(13).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الملاحظات").Bold().FontSize(7);
                            table.Cell().Row(1).Column(14).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("المستخدم").Bold().FontSize(7);
                        }
                        else if (pdfDto.reportType == ReportType.bill)
                        {

                            table.Cell().Row(1).Column(1).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("رقم العملية").Bold().FontSize(7);
                            table.Cell().Row(1).Column(2).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("التاريخ").Bold().FontSize(7);
                            table.Cell().Row(1).Column(3).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الوقت").Bold().FontSize(7);
                            table.Cell().Row(1).Column(4).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("رقم المركبة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(5).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الجنسية").Bold().FontSize(7);
                            table.Cell().Row(1).Column(6).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("التصنيف").Bold().FontSize(7);
                            table.Cell().Row(1).Column(7).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("وزن المركبة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(8).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الوزن المسموح").Bold().FontSize(7);
                            table.Cell().Row(1).Column(9).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("فرق الوزن").Bold().FontSize(7);
                            table.Cell().Row(1).Column(10).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("المخالفة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(11).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("رقم الوصل").Bold().FontSize(7);
                            table.Cell().Row(1).Column(12).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("رقم الضبط").Bold().FontSize(7);
                            table.Cell().Row(1).Column(13).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("اسم صاحب الفتورة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(14).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("المستخدم").Bold().FontSize(7);


                        }
                        else
                        {
                            table.Cell().Row(1).Column(1).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("الرقم").Bold().FontSize(7);
                            table.Cell().Row(1).Column(2).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("التاريخ").Bold().FontSize(7);
                            table.Cell().Row(1).Column(3).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("عدد عمليات التوزين").Bold().FontSize(7);
                            table.Cell().Row(1).Column(4).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("عدد المركبات غير المخالفة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(5).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("عدد المركبات المخالفة").Bold().FontSize(7);
                            table.Cell().Row(1).Column(6).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("عدد المركبات المخالفة < 5 ").Bold().FontSize(7);
                            table.Cell().Row(1).Column(7).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("عدد المركبات المخالفة > 5").Bold().FontSize(7);
                            table.Cell().Row(1).Column(8).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("مجموع الاوزان المخالف عليها").Bold().FontSize(7);
                            table.Cell().Row(1).Column(9).Background(Color.FromHex("#dcdcdc")).Element(CellStyle).AlignTop().Text("مجموع المخالفات دينار").Bold().FontSize(7);
                        }
                        uint counter = 2;
                        foreach (var item in pdfDto.ReportData)
                        {
                            if (pdfDto.reportType == ReportType.daily || pdfDto.reportType == ReportType.vehicle)
                            {
                                table.Cell().Row(counter).Column(1).Element(CellStyle).AlignTop().Text(item.Number).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(2).Element(CellStyle).AlignTop().Text(item.OperationNumber).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(3).Element(CellStyle).AlignTop().Text(item.DateOnly).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(4).Element(CellStyle).AlignTop().Text(item.TimeOnly).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(5).Element(CellStyle).AlignTop().Text(item.TruckNumber).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(6).Element(CellStyle).AlignTop().Text(item.Nationality).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(7).Element(CellStyle).AlignTop().Text(item.Classification).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(8).Element(CellStyle).AlignTop().Text(item.TruckWeiht).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(9).Element(CellStyle).AlignTop().Text(item.AllowedWeight).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(10).Element(CellStyle).AlignTop().Text(item.DiifWeight).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(11).Element(CellStyle).AlignTop().Text(item.Violation).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(12).Element(CellStyle).AlignTop().Text(item.ProductName).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(13).Element(CellStyle).AlignTop().Text(item.WeightNote).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(14).Element(CellStyle).AlignTop().Text(item.UserName).Bold().FontSize(7);
                            }
                            else if (pdfDto.reportType == ReportType.bill)
                            {
                                table.Cell().Row(counter).Column(1).ScaleToFit().ScaleToFit().Element(CellStyle).AlignTop().Text(item.OperationNumber).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(2).ScaleToFit().Element(CellStyle).AlignTop().Text(item.DateOnly).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(3).ScaleToFit().Element(CellStyle).AlignTop().Text(item.TimeOnly).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(4).ScaleToFit().Element(CellStyle).AlignTop().Text(item.TruckNumber).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(5).ScaleToFit().Element(CellStyle).AlignTop().Text(item.Nationality).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(6).ScaleToFit().Element(CellStyle).AlignTop().Text(item.Classification).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(7).ScaleToFit().Element(CellStyle).AlignTop().Text(item.TruckWeiht).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(8).ScaleToFit().Element(CellStyle).AlignTop().Text(item.AllowedWeight).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(9).ScaleToFit().Element(CellStyle).AlignTop().Text(item.DiifWeight).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(10).ScaleToFit().Element(CellStyle).AlignTop().Text(item.Violation).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(11).ScaleToFit().Element(CellStyle).AlignTop().Text(item.Bill_Num).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(12).ScaleToFit().Element(CellStyle).AlignTop().Text(item.Vio_Num).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(13).ScaleToFit().Element(CellStyle).AlignTop().Text(item.Bill_Name).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(14).ScaleToFit().Element(CellStyle).AlignTop().Text(item.UserName).Bold().FontSize(7);

                            }
                            else
                            {
                                table.Cell().Row(counter).Column(1).Element(CellStyle).AlignTop().Text(item.Number).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(2).Element(CellStyle).AlignTop().Text(item.DateOnly).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(3).Element(CellStyle).AlignTop().Text(item.TotalNumberWeights).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(4).Element(CellStyle).AlignTop().Text(item.TotalTruckesNotInViolation).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(5).Element(CellStyle).AlignTop().Text(item.TotalTruckesViolation).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(6).Element(CellStyle).AlignTop().Text(item.TotalTruckesViolationLessThan5).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(7).Element(CellStyle).AlignTop().Text(item.TotalTruckesViolationGreaterThan5).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(8).Element(CellStyle).AlignTop().Text(item.TotalViolationWeights).Bold().FontSize(7);
                                table.Cell().Row(counter).Column(9).Element(CellStyle).AlignTop().Text(item.TotalViolationPrice).Bold().FontSize(7);
                            }
                            counter++;
                        }
                    });

                });
                //page.Footer().AlignCenter().Text("وزارة الأشغال العامة والإسكان - 2024");
            });

        }
        private void GetHeader(IContainer container)
        {
            var reportText = pdfDto.reportType != ReportType.bill ? "تقرير" : "";
            container.Grid(grid =>
           {
               grid.VerticalSpacing(15);
               grid.HorizontalSpacing(15);
               grid.AlignCenter();


               grid.Item(8).Text(@$"المملكة الأردنية الهاشمية
وزارة الأشغال العامة والإسكان - وحدة الحمولات المحورية
{pdfDto.SiteName} ({pdfDto.SiteTitle})
{reportText} {pdfDto.ReportTypeText}
").AlignCenter().Bold().FontSize(13).ParagraphSpacing(3);
               grid.Item(4).Width(130).AlignLeft().Image(Path.Combine(Environment.CurrentDirectory, "wwwroot", "images", "PDF", "img1.png"));

               grid.Item(9).AlignRight().Text("التاريخ: " + DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).Bold();
               //grid.Item(3).AlignRight().Text(GetTotalPages(CurrentPage)).Bold();
               grid.Item(12).AlignRight().Text("");
               CurrentPage++;
           });
        }

        private void GetMainTable(IContainer container)
        {
            container.Table(table =>
            {

                // Add more rows as necessary
            });
        }
        private IContainer CellStyle(IContainer container)
        {
            return container.Border(1).Padding(5).AlignCenter().DefaultTextStyle(TextStyle.Default.Size(12));
        }
    }
}
