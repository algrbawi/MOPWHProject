using System;
using System.Collections.Generic;
using aspnetcore.ntier.DAL.Entities;

namespace aspnetcore.ntier.DAL.Entities;

public partial class SiteTbl
{
    public decimal SiteId { get; set; }

    public decimal? SiteCode { get; set; }

    public string? SiteName { get; set; }

    public string? SiteLocation { get; set; }

    public string? SiteTitle { get; set; }

    public bool? SiteState { get; set; }

    public virtual ICollection<LogTbl> LogTbls { get; set; } = new List<LogTbl>();

    public virtual ICollection<PicturesTbl> PicturesTbls { get; set; } = new List<PicturesTbl>();

    public virtual ICollection<ProductsTbl> ProductsTbls { get; set; } = new List<ProductsTbl>();

    public virtual ICollection<SettingTbl> SettingTbls { get; set; } = new List<SettingTbl>();

    public virtual ICollection<TrucksTbl> TrucksTbls { get; set; } = new List<TrucksTbl>();

    public virtual ICollection<UsersTbl> UsersTbls { get; set; } = new List<UsersTbl>();

    public virtual ICollection<WeightClassTbl> WeightClassTbls { get; set; } = new List<WeightClassTbl>();

    public virtual ICollection<WeightTicketTbl> WeightTicketTbls { get; set; } = new List<WeightTicketTbl>();
}
