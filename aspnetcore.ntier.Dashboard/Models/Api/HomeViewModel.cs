using aspnetcore.ntier.DTO.DTOs;

namespace aspnetcore.ntier.Dashboard.Models.Api
{
    public class HomeViewModel
    {
        public List<SiteTblDto> Sites { get; set; }
        public List<LogTblDto> Logs { get; set; }
    }
}
