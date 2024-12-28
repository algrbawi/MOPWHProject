using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class CameraTbl
{
    public decimal CamId { get; set; }

    public string? CamName { get; set; }

    public string? CamIp { get; set; }

    public int? CamPort { get; set; }

    public string? CamUsername { get; set; }

    public string? CamPassword { get; set; }

    public string? CamModel { get; set; }

    public bool? CamState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }
}
