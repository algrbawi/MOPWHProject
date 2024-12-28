using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class UsersPerTbl
{
    public decimal UpId { get; set; }

    public decimal? UpCode { get; set; }

    public bool? UpState { get; set; }

    public string? UpNote { get; set; }

    public decimal? UserPId { get; set; }

    public decimal? UserId { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual UsersTbl? User { get; set; }

    public virtual UserPSettingTbl? UserP { get; set; }
}
