using aspnetcore.ntier.DTO.DTOs;

namespace aspnetcore.ntier.Dashboard.Models.DashboardUser
{
    public class ReportDetailsResponseViewModel
    {
        public List<WeightTblDto> Weights { get; set; }
        public SiteTblDto Site { get; set; }
        public int SiteId { get; set; }
        public DateOnly? Date { get; set; }
        public DateType? DateType { get; set; }
        public string DateTypeText
        {
            get
            {
                return this.DateType switch
                {

                    null => "",
                    DTO.DTOs.DateType.daily => "يومي",
                    DTO.DTOs.DateType.monthly => "شهري",
                    DTO.DTOs.DateType.yearly => "سنوي"
                };

            }
        }
    }
}
