using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class NationTbl
{
    public decimal NationId { get; set; }

    public decimal? NationCode { get; set; }

    public string? NationName { get; set; }

    public bool? NationState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();
}
