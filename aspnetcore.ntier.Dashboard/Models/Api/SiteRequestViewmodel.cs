namespace aspnetcore.ntier.Dashboard.Models.Api
{
    public class SiteRequestViewmodel
    {
        public decimal SiteId { get; set; }

        public decimal? SiteCode { get; set; }

        public string? SiteName { get; set; }

        public string? SiteLocation { get; set; }

        public string? SiteTitle { get; set; }

        public bool? SiteState { get; set; }
    }
}
