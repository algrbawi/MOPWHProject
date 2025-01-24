using aspnetcore.ntier.DAL.Entities;
using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class SiteTbl
{
    public decimal SiteId { get; set; }

    public decimal? SiteCode { get; set; }

    public string? SiteName { get; set; }

    public string? SiteLocation { get; set; }

    public string? SiteTitle { get; set; }

    public bool? SiteState { get; set; }

    public virtual ICollection<CameraTbl> CameraTbls { get; set; } = new List<CameraTbl>();

    public virtual ICollection<ComScreenSetting> ComScreenSettings { get; set; } = new List<ComScreenSetting>();

    public virtual ICollection<ComSettingTbl> ComSettingTbls { get; set; } = new List<ComSettingTbl>();

    public virtual ICollection<DriversTbl> DriversTbls { get; set; } = new List<DriversTbl>();

    public virtual ICollection<LogTbl> LogTbls { get; set; } = new List<LogTbl>();

    public virtual ICollection<NationTbl> NationTbls { get; set; } = new List<NationTbl>();

    public virtual ICollection<PicturesTbl> PicturesTbls { get; set; } = new List<PicturesTbl>();

    public virtual ICollection<ProductsTbl> ProductsTbls { get; set; } = new List<ProductsTbl>();

    public virtual ICollection<SettingTbl> SettingTbls { get; set; } = new List<SettingTbl>();

    public virtual ICollection<TrucksTbl> TrucksTbls { get; set; } = new List<TrucksTbl>();

    public virtual ICollection<UsersPerTbl> UsersPerTbls { get; set; } = new List<UsersPerTbl>();

    public virtual ICollection<UsersTbl> UsersTbls { get; set; } = new List<UsersTbl>();

    public virtual ICollection<WeightClassTbl> WeightClassTbls { get; set; } = new List<WeightClassTbl>();

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();

    public virtual ICollection<WeightTicketTbl> WeightTicketTbls { get; set; } = new List<WeightTicketTbl>();

    public virtual ICollection<AccessUser> AccessUsers { get; set; } = new List<AccessUser>();

}
