using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.DAL.Entities;

public partial class TrucksTbl
{
    public decimal TruckId { get; set; }

    public decimal? TruckCode { get; set; }

    public string TruckNum { get; set; } = null!;

    public bool? TruckState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();
}
