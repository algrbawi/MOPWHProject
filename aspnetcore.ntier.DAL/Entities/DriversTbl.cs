using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class DriversTbl
{
    public decimal DriverId { get; set; }

    public decimal? DriverCode { get; set; }

    public string? DriverName { get; set; }

    public bool? DriverState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();
}
