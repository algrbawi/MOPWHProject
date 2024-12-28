using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class UserPSettingTbl
{
    public decimal UserPId { get; set; }

    public decimal? UserPCode { get; set; }

    public string? UserPForm { get; set; }

    public string? UserPName1 { get; set; }

    public string? UserPName2 { get; set; }

    public bool? UserPState { get; set; }

    public string? UserPNote { get; set; }

    public decimal? SiteId { get; set; }

    public virtual ICollection<UsersPerTbl> UsersPerTbls { get; set; } = new List<UsersPerTbl>();
}
