using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class SettingTbl
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Cprinter { get; set; }

    public string? Rprinter { get; set; }

    public string? Indecator { get; set; }

    public string? Note { get; set; }

    public bool? State { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }
}
