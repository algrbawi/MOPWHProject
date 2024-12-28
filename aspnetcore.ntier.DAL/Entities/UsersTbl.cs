using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class UsersTbl
{
    public decimal UserId { get; set; }

    public decimal? UserCode { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? UserType { get; set; }

    public bool? UserState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual ICollection<LogTbl> LogTbls { get; set; } = new List<LogTbl>();

    public virtual SiteTbl? Site { get; set; }

    public virtual ICollection<UsersPerTbl> UsersPerTbls { get; set; } = new List<UsersPerTbl>();

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();
}
