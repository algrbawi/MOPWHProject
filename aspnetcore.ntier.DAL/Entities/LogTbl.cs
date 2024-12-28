using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class LogTbl
{
    public decimal LogId { get; set; }

    public decimal? LogCode { get; set; }

    public string? LogName { get; set; }

    public DateOnly? LogDate { get; set; }

    public TimeOnly? LogTime { get; set; }

    public string? LogTrans { get; set; }

    public decimal? UserId { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual UsersTbl? User { get; set; }
}
