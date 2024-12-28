using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class ProductsTbl
{
    public decimal ProductId { get; set; }

    public decimal? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public string? ProductLocation { get; set; }

    public bool? ProductState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();
}
